INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'ADV', N'Credit Advances', N'1030', 1, 0, 0, 0, 1, 0, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'CST', N'Costs', N'5000', 1, 0, 0, 0, 0, 1, 0, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'ERN', N'Deposit Container', N'1910', 1, 0, 0, 0, 0, 1, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'EXPEN', N'Company expenses', N'', 0, 0, 0, 0, 0, 1, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'FR0', N'Freights (NO-WHT)', N'4050', 1, 2, 0, 0, 1, 0, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'FR1', N'Freights (WHT)', N'4050', 1, 1, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'PD', N'Products ', N'', 0, 1, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'SRV', N'Services (Vat 7,WHT 3)', N'4010', 1, 1, 1, 3, 0, 0, 0, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'TRN', N'Transportations', N'4060', 1, 0, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-001', N'ค่าภาษีอากร', N'Duty And Taxes', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, NULL)
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-002', N'ค่าระวางเรือ', N'Sea Frieght', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-003', N'ค่า D/O', N'Delivery Order Charge', 0, N'SHP', N'THB', N'HYUNDAI', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-004', N'B/L', N'Bill of Lading', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-005', N'ค่าแรงงาน', N'Labour charges', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-006', N'ค่าล้างตู้', NULL, 200, N'CNTR', N'THB', N'MOL', NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-007', N'ค่าซ่อมตู้', NULL, 1500, N'CTNR', N'THB', N'APLT', NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-008', N'THC', N'THC', 0, N'SHP', N'THB', N'LTD', N'', N'10001', N'10001', 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-010', N'ค่าโกดัง', N'ค่าโกดัง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-011', N'OVERTIME CUSTOMS', N'OVERTIME CUSTOMS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-012', N'CUSTOMS  FEE', N'CUSTOMS  FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-013', N'ค่าธรรมเนียมเอเย่นต์', N'ค่าธรรมเนียมเอเย่นต์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-014', N'ค่าผ่านท่า', N'Gate Charge', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-015', N'ค่าล่วงเวลาเอเย่นต์', N'ค่าล่วงเวลาเอเย่นต์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-017', N'Gate Free CHarge', N'Gate Free CHarge', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-018', N'ค่ายกตู้', N'ค่ายกตู้', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-019', N'ค่าขนส่ง', N'ค่าขนส่ง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-020', N'ค่าใช้จ่ายฉุกเฉิน', N'Contingency Charge', 0, N'SHP', N'THB', N'HYUNDAI', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-021', N'CO CHAMBER', N'CO CHAMBER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-022', N'ค่าใบรับรองปลอดศัตรูพืช', N'PHYTOSANITARY CERTIFICATE', 0, N'SHP', N'THB', N'', N'ค่าใบรับรองปลอดศัตรูพืช', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-023', N'ค่าบริการแลก D/O หัก 1%', N'Delivery Order Charge', 0, N'SHP', N'THB', N'HYUNDAI', N'', N'', N'', 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-024', N'ค่าบริการแลก D/O หัก 3%', N'Delivery Order Charge', 0, N'SHP', N'THB', N'HYUNDAI', N'', N'', N'', 1, 1, 3, 1, 0, 0, 1, 0, 1, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-025', N'Handling Fee', N'Handling Fee', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-026', N'CFS', N'CFS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-027', N'Status Fee', N'Status Fee', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-028', N'PORT FACILIY', N'PORT FACILIY', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-029', N'IMO2020 Low Sulphur Surcharge', N'IMO2020 Low Sulphur Surcharge', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-030', N'Delivery Order Fee', N'Delivery Order Fee', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-031', N'C/O CHAMBER', N'C/O CHAMBER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-032', N'C/O กระทรวงการต่างประเทศ', N'C/O กระทรวงการต่างประเทศ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-033', N'TOT', N'TOT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-034', N'FAC', N'FAC', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-035', N'TERMINAL HANDLING CHARGE', N'TERMINAL HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-036', N'CGS', N'CGS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-037', N'ค่าพิธีการตรวจปล่อย', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-038', N'CY CHARGE', N'CY CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-039', N'EXTRA RECOVERY ', N'EXTRA RECOVERY ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-040', N'PCS', N'PCS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-041', N'EMC', N'EMC', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-042', N'LSS', N'LSS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-043', N'เศษสตางค์', N'เศษสตางค์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-044', N' DUTY  TAX', N' DUTY  TAX', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-045', N'DEMURRAGE', N'DEMURRAGE', 0, N'SHP', N'THB', N'', N'', N'DEMURRAGE', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-046', N'เซอร์เซ็ค', N'เซอร์เซ็ค', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-047', N'ค่าธรรมเนียมผ่านแดน', N'ค่าธรรมเนียมผ่านแดน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-048', N'ค่าธรรมเนียม ค่าธ.ประจำการนอกเขต+ค่าเดินทาง', N'ค่าธรรมเนียม ค่าธ.ประจำการนอกเขต+ค่าเดินทาง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-049', N'ค่าธรรมเนียมคุมเฝ้า', N'ค่าธรรมเนียมคุมเฝ้า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-050', N'ค่าล่วงเวลา วัดถัง+ตรวจปล่อย', N'ค่าล่วงเวลา วัดถัง+ตรวจปล่อย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-051', N'ค่าธรรมเนียมประจำการนอกเขต', N'ค่าธรรมเนียมประจำการนอกเขต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-052', N'CARGO DUES OIL TANKER', N'CARGO DUES OIL TANKER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-053', N'กรมการค้าต่างประเทศ', N'กรมการค้าต่างประเทศ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-054', N'EMCI', N'EMCI', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-055', N'CIC', N'CIC', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-056', N'CLCO', N'CLCO', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-057', N'DOC', N'DOC', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-058', N'ELE', N'ELE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-059', N'SEAFRIGHT CHARGE', N'SEAFRIGHT CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-060', N'FUEL ADJUSTMENT FACTOR', N'FUEL ADJUSTMENT FACTOR', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-061', N'YAS', N'YAS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-062', N'TERMINAL HANDLING CHARGE', N'TERMINAL HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-063', N'DOCUMENTATION FEE', N'DOCUMENTATION FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-064', N'SEAL ', N'SEAL', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-065', N'FORWARDING', N'FORWARDING', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-066', N'TERMINAL HANDLING CHARGE', N'TERMINAL HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-067', N'DO', N'DO', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-068', N'CONTAINER CLEANING CHARGE', N'CONTAINER CLEANING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-069', N'CONTAINER IMBALANCE SURCHARGES', N'CONTAINER IMBALANCE SURCHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-070', N'EQUIPMENT IMBALANCE SURCHARGES', N'EQUIPMENT IMBALANCE SURCHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-071', N'HANDLING CHARGE', N'HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-072', N'ค่าสำรองตรวจปล่อย', N'ค่าสำรองตรวจปล่อย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-073', N'CONTAINER MAINTENANCE CHARGES', N'CONTAINER MAINTENANCE CHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-074', N'ELE', N'ELE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-075', N'ค่าสำรอง + ค่า D/O', N'ค่าสำรอง + ค่า D/O', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-076', N'ค่ายานพาหนะ', N'ค่ายานพาหนะ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-078', N'DOC FEE DEST', N'DOC FEE DEST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-079', N'COLLECTION OF CNTR', N'COLLECTION OF CNTR', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-080', N'CTNR STATUS CHARGE', N'CTNR STATUS CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-081', N'BL AMENDMENT FEE', N'BL AMENDMENT FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-082', N'CTNR STAUS CHARGE', N'CTNR STAUS CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-083', N'ค่าภาษีอากร + ค่า D/O + ค่าสำรอง', N'ค่าภาษีอากร + ค่า D/O + ค่าสำรอง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-084', N'ค่าใบป่วยการรับรองศัตรูพืช', N'ค่าใบรับรองศัตรูพืช', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-085', N'ค่าตะกั่ว', N'ค่าตะกั่ว', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-086', N'LCL CHARGES', N'LCL CHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-087', N'DO FEES', N'DO FEES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-090', N'CONTAINER FREIGHT STATION', N'CONTAINER FREIGHT STATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-091', N'STATUS CHARGE', N'STATUS CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-092', N'CONGESTION SURCHARGE', N'CONGESTION SURCHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-093', N'BUNKER ADJUSTMENT FACTOR', N'BUNKER ADJUSTMENT FACTOR', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-094', N'ECC-ENVIRONMENTAL COMPLIANCE CHARGE', N'ECC-ENVIRONMENTAL COMPLIANCE CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-095', N'DOD-DOC FEE AT DESTINATION', N'DOD-DOC FEE AT DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-096', N'CGC-CONTINGENCY CHARGE', N'CGC-CONTINGENCY CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-097', N'THD-THC IN DISCHARGING', N'THD-THC IN DISCHARGING', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-098', N'EQC-EQUIPMENT CHARGE', N'EQC-EQUIPMENT CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-099', N'หอการค้าไทย', N'หอการค้าไทย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-100', N'ค่าสำรอง', N'ค่าสำรอง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-101', N'STATUS', N'STATUS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-102', N'FACILOTIES CHARGES AT DEST', N'FACILOTIES CHARGES AT DEST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-103', N'CONGESTION CHARGES AT DEST', N'CONGESTION CHARGES AT DEST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-104', N'WHARFAGE CHARGES AT DEST', N'WHARFAGE CHARGES AT DEST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-105', N'CONTAINER IMBALANCE CHARGE', N'CONTAINER IMBALANCE CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-106', N'ค่าส่งใบขน', N'ค่าส่งใบขน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-107', N'CLEANING CONTAINER FEE', N'CLEANING CONTAINER FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-108', N'THAILAND DOCUMENTATION CHARGE', N'THAILAND DOCUMENTATION CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-109', N'CCF', N'CCF', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-110', N'DCF', N'DCF', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-111', N'CIS', N'CIS', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-112', N'CMC', N'CMC', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-113', N'CCF', N'CCF', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-114', N'BANGKOK CONTIGENCY SURCHARGE', N'BANGKOK CONTIGENCY SURCHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-115', N'CONTAINER GUARANTEE', N'CONTAINER GUARANTEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-116', N'CLEANING', N'CLEANING', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-117', N'ค่าธรรมเนียมรับรองเอกสาร', N'ค่าธรรมเนียมรับรองเอกสาร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-118', N'S/C', N'S/C', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-119', N'BAF', N'BAF', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-120', N'CAF', N'CAF', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-121', N'LOW SULPHUR SURCHARG', N'LOW SULPHUR SURCHARG', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-122', N'FACILITIES', N'FACILITIES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-123', N'CONTAINER IMBALANCE CHARGE', N'CONTAINER IMBALANCE CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-124', N'CONTAINER SHIFTING DESTINATION', N'CONTAINER SHIFTING DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-125', N'TERMINAL HANDLING SERVICE-DESTINATION', N'TERMINAL HANDLING SERVICE-DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-126', N'DISCHARGING TERMINAL HANDLING', N'DISCHARGING TERMINAL HANDLING', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-127', N'DESTINATION DOCUMENTATION FEE', N'DESTINATION DOCUMENTATION FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-128', N'CLEANING CHG', N'CLEANING CHG', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-129', N'EQUIPMENT CLEANING', N'EQUIPMENT CLEANING', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-130', N'TERMINAL HANDLING AT DEST.', N'TERMINAL HANDLING AT DEST.', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-131', N'EQUIPMENT MAINTENANCE CHARGES', N'EQUIPMENT MAINTENANCE CHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-132', N'THAILAND TERMINAL HANDLING CHARGES', N'THAILAND TERMINAL HANDLING CHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-133', N'FACILITIES', N'FACILITIES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-134', N'LOCAL CHARGE', N'LOCAL CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-135', N'ค่าปรับกรมศุลกากร', N'ค่าปรับกรมศุลกากร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-136', N'DELIVERY ORDER FEE', N'DELIVERY ORDER FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-137', N'IMPORT DUTY AND VAT', N'IMPORT DUTY AND VAT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-138', N'FACILITY CHARGE', N'FACILITY CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-139', N'CLEANING CHARGE', N'CLEANING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-140', N'IMPORT EQUIPMENT MANAGEMENT SURCHAR', N'IMPORT EQUIPMENT MANAGEMENT SURCHAR', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-141', N'INBOUND DOCUMENTATION FEE', N'INBOUND DOCUMENTATION FEE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-142', N'TERMINAL HANDLING CHARGE AT DESTINATION', N'TERMINAL HANDLING CHARGE AT DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-143', N'THC AT DESTINATION', N'THC AT DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-144', N'FACILITIES USAGE CHARGE', N'FACILITIES USAGE CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-145', N'FREIGHT CHARGE-IMPORT', N'FREIGHT CHARGE-IMPORT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-146', N'EQUIPMENT MAINTENANCE PREMIUM', N'EQUIPMENT MAINTENANCE PREMIUM', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-147', N'DESTINATION', N'DESTINATION', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-148', N'PORT CONGESTION CHARGES', N'PORT CONGESTION CHARGES', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-149', N'ค่าทำเรื่องนำสินค้ากลับ', N'ค่าทำเรื่องนำสินค้ากลับ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-150', N'CONTINGENCY SURCHARGE', N'CONTINGENCY SURCHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-151', N'EBS-EMERGENCY BUNKER SUCHARGE', N'EBS-EMERGENCY BUNKER SUCHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-152', N'THC(TERMINAL HDL CHARGE)', N'THC(TERMINAL HDL CHARGE)', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-153', N'PORT CONGESTION SURCHARGE', N'PORT CONGESTION SURCHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-154', N'EX-WORKS CHARGE', N'EX-WORKS CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-155', N'CONTAINER CLEAN FEE-COLLECT', N'CONTAINER CLEAN FEE-COLLECT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-156', N'ค่าป่วยการตรวจพืชนอกสถานที่', N'ค่าป่วยการตรวจพืชนอกสถานที่', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-157', N'ค่าอุปกรณ์พิเศษ', N'ค่าอุปกรณ์พิเศษ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-158', N'ค่าส่งเอกสาร TNT', N'ค่าส่งเอกสาร TNT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-159', N'ค่าปรับภาษีอากร', N'ค่าปรับภาษีอากร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-161', N'ค่าธรรมเนียมกระทรวงพาณิชย์', N'ค่าธรรมเนียมกระทรวงพาณิชย์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-162', N'ค่ากรรมกรลงของ', N'ค่ากรรมกรลงของ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-163', N'ค่าคืนตู้', N'ค่าคืนตู้', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-164', N'ค่าธรรมเนียม C/O หอการค้า', N'ค่าธรรมเนียม C/O หอการค้า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-165', N'จ่ายภาษีเป็นเงินสด', N'จ่ายภาษีเป็นเงินสด', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-166', N'DETENTION ', N'DETENTION ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-167', N'จำลองใบขนขาออก', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-168', N'ค่าใบขนสินค้าขาออก', N'ค่าใบขนสินค้าขาออก', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-169', N'ค่าอากรขาออก', N'ค่าอากรขาออก', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-170', N'LINER''S CHARGE', N'LINER''S CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-171', N'STORAGE CHARGE', N'STORAGE CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-172', N'O.T.CUSTOMS BANGPU', N'O.T.CUSTOMS BANGPU', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-173', N'HANDLING CHARGE', N'HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-174', N'SURRENDER', N'SURRENDER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-175', N'SECURITY COMPLIANCE MANAGEMENT  CHARGE', N'SECURITY COMPLIANCE MANAGEMENT  CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-177', N'RETURN CONTAINER ', N'RETURN CONTAINER ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-178', N'OVERNIGHT CHARGE', N'OVERNIGHT CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-179', N'SHIPPING  CHARGE', N'SHIPPING  CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-180', N'SHIPPING  HANDLING CHARGE', N'SHIPPING  HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-181', N'F.O.B. HANDLING CHARGE', N'F.O.B.  HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-001', N'ต้นทุน-ค่าขนส่ง', N'ต้นทุน-ค่าขนส่ง', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-002', N'ต้นทุน-ค่าธรรมเนียมเอเย่นค์', N'ต้นทุน-ค่าธรรมเนียมเอเย่นค์', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-003', N'ต้นทุน-ค่ายื่นเช็คภาษี', N'ต้นทุน-ค่ายื่นเช็คภาษี', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-004', N'ต้นทุน-ค่านายตรวจ', N'ต้นทุน-ค่านายตรวจ', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-005', N'ต้นทุน-ค่าปล่อย wharf', N'ต้นทุน-ค่าปล่อย wharf', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-006', N'ต้นทุน-ค่าตัดซีล', N'ต้นทุน-ค่าตัดซีล', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-007', N'ต้นทุน-ค่าแรงงาน', N'ต้นทุน-ค่ารถยก', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-008', N'ต้นทุน-ค่ารื้อตู้', N'ต้นทุน-ค่ารื้อตู้', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-009', N'ต้นทุน-ค่า จนท ป่าไม้', N'ต้นทุน-ค่า จนท ป่าไม้', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-010', N'ต้นทุน-ค่า จนท ประมง', N'ต้นทุน-ค่า จนท ประมง', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-011', N'ต้นทุน-ค่าที่จอดรถ', N'ต้นทุน-ค่าที่จอดรถ', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-012', N'ค่าใบอนุญาต', N'ค่าใบอนุญาต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-013', N'ค่าคลังอันตราย', N'ค่าคลังอันตราย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-014', N'Gate Charge Lift On-Off', N'Gate Charge Lift On', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-015', N'ค่าบริการปล่อยของตู้ 2 ขึ้นไป', N'Next Container  2 ND', 0, N'SHP', N'THB', N'กรมศุลกากร', N'', N'', N'', 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-016', N'ค่าบริการชิปปิ้ง (สุวรรณภูมิ)', N'SHIPPING SERVICE CHARGE (SUVARNABHUMI)', 0, N'SHP', N'THB', N'', N'ค่าบริการชิปปิ้ง (สุวรรณภูมิ)', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-018', N'เศษสตางค์', N'เศษสตางค์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-019', N'ค่าพิธีการตรวจปล่อย', N'ค่าพิธีการตรวจปล่อย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-020', N'ค่าขนส่ง โรงงานมาบตาพุด จ.ระยอง-กิ่งแก้ว (2x20Ft)', N'ค่าขนส่ง โรงงานมาบตาพุด จ.ระยอง-กิ่งแก้ว (2x20Ft)', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-021', N'ค่าธรรมเนียม', N'ค่าธรรมเนียม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-022', N'ค่าโกดัง', N'ค่าโกดัง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-023', N'ค่าพิธีการผ่านแดน', N'ค่าพิธีการผ่านแดน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-025', N'ค่าคืนตู้เปล่า', N'ค่าคืนตู้เปล่า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-026', N'ค่าต่อระยะคืนตู้เปล่า', N'ค่าต่อระยะคืนตู้เปล่า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-027', N'ค่ายก-ย้ายตู้', N'ค่ายก-ย้ายตู้', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-028', N'ค่าคนงานลงสินค้า', N'ค่าคนงานลงสินค้า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-029', N'ค่ารอรับตู้ข้างเรือ', N'ค่ารอรับตู้ข้างเรือ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-030', N'ค่าปล่อยตั๋วอันตราย', N'ค่าปล่อยตั๋วอันตราย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-031', N'ค่าล่วงเวลากรมศุล', N'ค่าล่วงเวลากรมศุล', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-032', N'ค่าล่วงเวลาท่าเรือ', N'ค่าล่วงเวลาท่าเรือ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-033', N'ค่าเซอร์เช็ค', N'ค่าเซอร์เช็ค', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-034', N'ค่าผ่านเกษตร', N'ค่าผ่านเกษตร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-035', N'ค่าผ่านด่านป่าไม้', N'ค่าผ่านด่านป่าไม้', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-036', N'ค่าผ่านประมง', N'ค่าผ่านประมง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-037', N'ค่ารถรับเจ้าหน้าที่+แรงงาน', N'ค่ารถรับเจ้าหน้าที่+แรงงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-038', N'ค่าคนงานรื้อตู้ตรวจ', N'ค่าคนงานรื้อตู้ตรวจ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-039', N'ค่าธรรมเนียมในการผ่านแดน', N'ค่าธรรมเนียมในการผ่านแดน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-040', N'ปล่อย จัดเรียง ว๊าฟ', N'ปล่อย จัดเรียง ว๊าฟ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-041', N'ประซีนตะกั่ว ตัดคอม', N'ประซีนตะกั่ว ตัดคอม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-042', N'เซอร์เวย์ แรงงาน', N'เซอร์เวย์ แรงงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-043', N'ค่าตะกั่ว', N'ค่าตะกั่ว', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-044', N'ค่าถ่ายเอกสาร  ส่งFAX + ส่งเมล', N'ค่าถ่ายเอกสาร  ส่งFAX + ส่งเมล', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-045', N'ค่าเดินทาง', N'ค่าเดินทาง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-046', N'ค่าทางด่วน', N'ค่าทางด่วน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-047', N'NO MARKS+หน้าประตู', N'NO MARKS+หน้าประตู', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-048', N'นายตรวจ', N'นายตรวจ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-049', N'ค่าภาษีเงินสด', N'ค่าภาษีเงินสด', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-050', N'ค่าตัดซีนชักตัวอย่าง', N'ค่าตัดซีนชักตัวอย่าง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-051', N'ค่าภาษีสุรา กองทุน', N'ค่าภาษีสุรา กองทุน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-052', N'ค่าแผ่เหล้าปิดอากร', N'ค่าแผ่เหล้าปิดอากร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-053', N'หัวหน้าโกดัง', N'หัวหน้าโกดัง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-054', N'ค่าเดินทางเจ้าหน้าที่ สรรพสามิต', N'ค่าเดินทางเจ้าหน้าที่ สรรพสามิต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-055', N'ค่าดำเนินการซื้อแสตมป์', N'ค่าดำเนินการซื้อแสตมป์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-056', N'ค่ากาว', N'ค่ากาว', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-057', N'ค่าตอกรหัส', N'ค่าตอกรหัส', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-058', N'ปิดแสตมป์', N'ปิดแสตมป์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-059', N'ปิดสติกเกอร์', N'ปิดสติกเกอร์', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-060', N'ค่าข้าวสรรพสามิต', N'ค่าข้าวสรรพสามิต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-061', N'ค่ารับใบขนสุรา ออกเลข', N'ค่ารับใบขนสุรา ออกเลข', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-062', N'พิเศษท่าเรือ สายเรือ', N'พิเศษท่าเรือ สายเรือ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-063', N'เจ้าหน้าที่สรรพสามิต โค๊ตตัวที่2', N'เจ้าหน้าที่สรรพสามิต โค๊ตตัวที่2', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-064', N'พิเศษสรรพสามิต', N'พิเศษสรรพสามิต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-065', N'ค่าเจ้าหน้าที่ธุรการ', N'ค่าเจ้าหน้าที่ธุรการ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-066', N'งานคดี', N'งานคดี', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-067', N'ค่าตรวจสอบเอกสาร', N'ค่าตรวจสอบเอกสาร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-068', N'ค่าส่งใบอนุญาต', N'ค่าส่งใบอนุญาต', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-069', N'ค่าเจ้าหน้าที่คอม', N'ค่าเจ้าหน้าที่คอม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-070', N'ค่าเจ้าหน้าที่ชดเชยตรวจสอบ', N'ค่าเจ้าหน้าที่ชดเชยตรวจสอบ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-071', N'ค่ารับบัตรภาษี', N'ค่ารับบัตรภาษี', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-072', N'ค่าปรับ', N'ค่าปรับ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-073', N'ค่าออกหนังสือ', N'ค่าออกหนังสือ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-074', N'ค่าใบเคลม', N'ค่าใบเคลม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-075', N'ค่ารถตัก', N'ค่ารถตัก', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-076', N'ค่าคุมส่งตัวอย่าง อย.', N'ค่าคุมส่งตัวอย่าง อย.', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-077', N'ค่าเปเปอร์เรท', N'Paperless', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-078', N'ค่าอุปกรณ์พิเศษ', N'ค่าอุปกรณ์พิเศษ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-079', N'Tally', N'Tally', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-080', N'ศล.', N'ศล.', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-081', N'ค่าทำเอกสารต่ออายุ TOT', N'ค่าทำเอกสารต่ออายุ TOT', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-082', N'ค่าตัวอย่าง', N'ค่าตัวอย่าง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-083', N'ค่าส่งตัวอย่าง', N'ค่าส่งตัวอย่าง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-084', N'ค่าทำเอกสารขึ้นทะเบียน', N'ค่าทำเอกสารขึ้นทะเบียน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-085', N'ชั่งน้ำหนัก', N'ชั่งน้ำหนัก', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-086', N'ค่าตรวจคอม', N'ค่าตรวจคอม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-087', N'ค่าผ่านท่า', N'ค่าผ่านท่า', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-088', N'ค่าขนถ่ายสินค้านอกสถานที่', N'ค่าขนถ่ายสินค้านอกสถานที่', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-089', N'ปราบปราม', N'ปราบปราม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-090', N'อย', N'อย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-091', N'ผลักประกัน', N'ผลักประกัน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-092', N'CARGO DUES OIL TANKER', N'CARGO DUES OIL TANKER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-093', N'พิธีการถ่ายลำ', N'พิธีการถ่ายลำ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-094', N'พิธีการ OVER SIZE', N'พิธีการ OVER SIZE ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-095', N'หัวหน้านายตรวจ', N'หัวหน้านายตรวจ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-096', N'ใบกำกับ', N'ใบกำกับ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-097', N'ค่าธรรมเนียมกรมศุลกากร', N'ค่าธรรมเนียมกรมศุลกากร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-098', N'ค่าส่งใบขน', N'ค่าส่งใบขน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-099', N'ค่าซีล', N'ค่าซีล', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-100', N'ส่ง E', N'ส่ง E', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-101', N'ค่าพิธีการลาว', N'ค่าพิธีการลาว', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-102', N'CARGO DUES OIL TANKER', N'CARGO DUES OIL TANKER', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-103', N'ค่าริการตรวจปล่อยชิปปิ้งแหลมฉบัง', N'ค่าริการตรวจปล่อยชิปปิ้งแหลมฉบัง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-104', N'ค่าจำลองใบขน', N'ค่าจำลองใบขน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-105', N'RETURN  CONTAINER COST', N'RETURN  CONTAINER COST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-106', N'SHIPPING COST', N'SHIPPING COST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-107', N'TRANSPORT  COST', N'TRANSPORT  COST', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-108', N'DOCUMENT CHARGE', N'DOCUMENT CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-109', N'ค่าใช้จ่ายอื่นๆ', N'ค่าใช้จ่ายอื่นๆ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ERN-001', N'ค่ามัดจำตู้', N'Deposit Container', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'ERN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-001', N'ค่าน้ำมัน', N'ค่าน้ำมัน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-002', N'ค่าโทรศัพท์มือถือ', N'ค่าโทรศัพท์มือถือ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-003', N'ค่าธรรมเนียม', N'ค่าธรรมเนียม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-004', N'ค่าเช่า Mailbox และค่าบริการส่งข้อมูล Paper less', N'ค่าเช่า Mailbox และค่าบริการส่งข้อมูล Paper less', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-005', N'ค่าล่วงเวลา', N'ค่าล่วงเวลา', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-006', N'เงินเดือนพนักงาน', N'เงินเดือนพนักงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-007', N'ค่าแรงงานรายวัน', N'ค่าแรงงานรายวัน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-008', N'ค่าบริการทำบัญชี', N'ค่าบริการทำบัญชี', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-009', N'ประกันสังคมนายจ้างสมทบ', N'ประกันสังคมนายจ้างสมทบ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-010', N'เงินประเมินเงินสมทบกองทุนเงินทดแทน', N'เงินประเมินเงินสมทบกองทุนเงินทดแทน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-011', N'ภาษีเงินได้นิติบุคคล', N'ภาษีเงินได้นิติบุคคล', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-012', N'ภาษีเงินได้ประจำปี ', N'ภาษีเงินได้ประจำปี ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-013', N'ภาษีธุรกิจเฉพาะ ', N'ภาษีธุรกิจเฉพาะ ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-014', N'ค่าผู้ตรวจสอบงบการเงินประจำปี ', N'ค่าผู้ตรวจสอบงบการเงินประจำปี ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-015', N'ค่าบำรุงสมาชิกสมาคมชิปปิ้งไทย ประจำปี ', N'ค่าบำรุงสมาชิกสมาคมชิปปิ้งไทย ประจำปี ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-016', N'โบนัสพนักงาน', N'โบนัสพนักงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-017', N'ค่าเน็ท', N'ค่าเน็ท', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-018', N'ค่าเช่าโกดัง  ', N'ค่าเช่าโกดัง  ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-019', N'ค่าน้ำประปา', N'ค่าน้ำประปา', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-020', N'ค่ารักษาความปลอดภัย', N'ค่ารักษาความปลอดภัย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-021', N'ค่าไฟฟ้า ', N'ค่าไฟฟ้า ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-022', N'ค่าสวัสดิการพนักงาน', N'ค่าสวัสดิการพนักงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-023', N'ค่าอุปกรณ์ สำนักงาน ', N'ค่าอุปกรณ์ สำนักงาน ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-024', N'ค่ากำจัดปลวก ', N'ค่ากำจัดปลวก', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-025', N'ค่าเบี้ยประกันภัย', N'ค่าเบี้ยประกันภัย', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-026', N'ค่าซ่อมรถโฟกลิฟ ', N'ค่าซ่อมรถโฟกลิฟ ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-027', N'ค่าเช่ารถโฟกลิฟ ', N'ค่าเช่ารถโฟกลิฟ ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-028', N'ค่าใช้จ่ายเบ็ดเตล็ด', N'ค่าใช้จ่ายเบ็ดเตล็ด', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-029', N'ค่าตำรวจ (ตู้แดง)', N'ค่าตำรวจ (ตู้แดง)', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-030', N'ค่าน้ำมันรถโฟกลิฟ', N'ค่าน้ำมันรถโฟกลิฟ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-031', N'ค่าโทรศัพท์ในประเทศ', N'ค่าโทรศัพท์ในประเทศ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-032', N'ค่าเช่าเครื่องถ่ายเอกสาร', N'ค่าเช่าเครื่องถ่ายเอกสาร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-033', N'ค่าบำรุงรักษาเครื่องถ่ายเอกสาร', N'ค่าบำรุงรักษาเครื่องถ่ายเอกสาร', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-034', N'ค่าเช่าสำนักงาน', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-035', N'ภงด.3', N'ภงด.3', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-036', N'ภงด.1', N'ภงด.1', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-037', N'ภงด.53', N'ภงด.53', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-038', N'ภงด.3 แทน', N'ภงด.3 แทน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-039', N'ภงด.53 แทน', N'ภงด.53 แทน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-040', N'ภพ.30', N'ภพ.30', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-041', N'ค่าธรรมเนียม', N'ค่าธรรมเนียม', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-042', N'ประกันสังคมลูกจ้างสมทบ', N'ประกันสังคมลูกจ้างสมทบ', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-043', N'ค่าซ่อมอุปกรณ์สำนักงาน', N'ค่าซ่อมอุปกรณ์สำนักงาน', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-044', N'วัสดุ์สิ้นเปลือง', N'วัสดุ์สิ้นเปลือง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-045', N'ค่าเช่ารถกรรมการ', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-046', N'ค่าพาหนะ', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-047', N'สัญญาประนอมหนี้', N'', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'EXPEN-048', N'ค่าอุปกรณ์สำนักงาน', N'Office Equipment Expenses', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, N'EXPEN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'FR1-001', N'ค่าระวาง', N'ค่าระวาง', 0, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'FR1')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'FR1-002', N'ค่า THC', N'ค่า THC', 0, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'FR1')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'PD-001', N'COMPUTER', N'COMPUTER', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'PD')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-001', N'IMPORT CUSTOMS CLEARANCE EXPENSE', N'IMPORT CUSTOMS CLEARANCE EXPENSE', 3000, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-002', N'ค่าบริการขาออก', N'Export Service Charges', 3000, N'SHP', N'THB', NULL, NULL, NULL, NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-003', N'ค่าขนส่ง', N'ค่าขนส่ง', 0, N'SHP', N'THB', N'', N'', N'', N'', 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-005', N'Service Charge', N'Service Charge', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-006', N'Transportation Charge Laem Chabang ', N'Transportation Charge Laem Chabang ', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-007', N'Transportation Charge Bangkok', N'Transportation Charge Bangkok', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-008', N'Transportation Charge Golden', N'Transportation Charge Golden', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-009', N'In Transit', N'In Transit', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-010', N'Lift On,Lift Off,Gate Charge', N'Lift On,Lift Off,Gate Charge', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-011', N'The Cargo Handing', N'The Cargo Handing', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-012', N'Demurrage', N'Demurrage', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-013', N'Detention', N'Detention', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-014', N'Bank Fee', N'Bank Fee', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-015', N'Fuel Fee', N'Fuel Fee', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-017', N'ค่าบริการ C/O', N'ค่าบริการ C/O', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-018', N'ค่าบริการชดเชย', N'ค่าบริการชดเชย', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-019', N'ค่าบริการ 19 ทวิ', N'ค่าบริการ 19 ทวิ', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-020', N'ค่าบริการ C/O หอการค้า', N'ค่าบริการ C/O หอการค้า', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-021', N'DOCUMENT CHARGE', N'DOCUMENT CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-022', N'CUSTOMS INSPECTION', N'CUSTOMS INSPECTION', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-023', N'CONTAINER RETRUN', N'CONTAINER RETRUN', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-024', N'TRANSPORT  CHARGE', N'TRANSPORT  CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-025', N'SHIPPING  FIRST CONTAINER @1500 BAHT', N'SHIPPING  FIRST CONTAINER @1500 BAHT', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-026', N'SHIPPING  NEXT CONTAINER @1000 BAHT', N'SHIPPING  NEXT CONTAINER @1000 BAHT', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-027', N'F.O.B. HANDLING CHARGE', N'F.O.B. HANDLING CHARGE', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-028', N'EXPORT CUSTOMS CLEARANCE EXPENSE', N'EXPORT CUSTOMS CLEARANCE EXPENSE', 0, N'SHP', N'THB', N'', N'', N'', N'', 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'TRN-001', N'ค่าขนส่ง', N'', 0, N'', N'', N'', N'', N'', N'', 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, N'TRN')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'TRN-002', N'ค่าบริการขนส่ง', N'ค่าบริการขนส่ง', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, N'TRN')
GO
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode]) VALUES (N'', N'OFFICE', N'สมุดบัญชีค่าใช้จ่ายออฟฟิศ', N'000', N'', 0, N'S', N'', N'', N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode]) VALUES (N'', N'RECEIVED', N'สมุดบัญชีรายรับ', N'000', N'', 0, N'S', N'', N'', N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode]) VALUES (N'00', N'CL', N'สมุกบัญชีเงินทดลองจ่าย', N'000', N'', 0, N'S', N'', N'', N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Mas_Branch] ([Code], [BrName]) VALUES (N'00', N'สำนักงานใหญ่')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'ADMIN', N'9t;yogm8', N'ADMINISTRATOR', N'ADMINISTRATOR', N'ADMINISTRATOR', NULL, NULL, NULL, NULL, 99, 0, 0, N'11111111111111111', N'', N'', 1, 0, 0, N'', N'', N'TH', N'', N'', N',01,02,03,04,05,06', N',01,02,03,04', N'6')
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
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'Role', N'MEIRDP')
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
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Bank', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Branch', N'MEIRDP')
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
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Index', N'MEIRDP')
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
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Users', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Venders', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Vessel', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Dashboard', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Export', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Import', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Reports', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'Quotation', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC', N'Accounting Staff', 5)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC-MGR', N'Accounting Manager', 5)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS', N'Customer Services Staff', 2)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS-MGR', N'Customer Services Manager', 2)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CUST', N'Customers', 0)
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
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'VEND', N'Venders', 0)
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CUST', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT_MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Adjustment', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Cheque', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Costing', N'MIREDP')
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
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/TruckApprove', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_MAS/Customers', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_MAS/TransportRoute', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_REP/Index', N'MIREDP')
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
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_MAS/TransportRoute', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CUST', N'MODULE_CS/CreateJob', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CUST', N'MODULE_CS/ShowJob', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CUST', N'MODULE_CS/Transport', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CUST', N'MODULE_MAS/Customers', N'MIREDP')
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
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/TruckApprove', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_MAS/TransportRoute', N'MIREDP')
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
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_ACC/Expense', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_CS/Transport', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_CS/TruckApprove', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_MAS/TransportRoute', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_MAS/Venders', N'MIREDP')
GO
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EVG00', N'0000', N'010554015421', N'', N'EVERGREEN SHIPPING AGENCY (THAILAND) CO., LTD.', N'EVERGREEN SHIPPING AGENCY (THAILAND) CO., LTD.', N'3656/81, 24-25TH FLR., GREEN TOWER, RAMA 4 ROAD,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', N'3656/81, 24-25TH FLR., GREEN TOWER, RAMA 4 ROAD,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', N'02-2299999', N'02-3673422-24', N'', N'', N'', N'', N'', N'', N'', N'', N'')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'01', N'รออนุมัติ (REQUEST)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'02', N'อนุมัติแล้ว(APPROVED)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'03', N'รอเคลียร์เงิน (PAYMENTED)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'04', N'ปิดมาแล้วบางส่วน (PART-CLEARING)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'05', N'ปิดมาครบแล้ว (FULL-CLEARING)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'06', N'เคลียร์เงินแล้ว (CLEARED)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'99', N'ยกเลิก (CANCELLED)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'01', N'ค่าใช้จ่ายการเตรียมงาน (C/S)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'02', N'ค่าดำเนินการทางพิธีการ (C/S)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'03', N'ค่าใช้จ่ายในระหว่างการตรวจปล่อย (S/P)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'04', N'ค่าใช้จ่ายอื่นๆ หลังการตรวจปล่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'C', N'รอเคลียริ่ง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'P', N'เช็คผ่าน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'R', N'เช็คคืน')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'01', N'รออนุมัติ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'02', N'อนุมัติแล้ว')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'03', N'เคลียร์เงินแล้ว')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'04', N'BILLED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'99', N'ยกเลิก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'1', N'เงินทดรองจ่ายเรียกเก็บได้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'2', N'ต้นทุนเรียกเก็บไม่ได้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'3', N'ค่าบริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNS', N'CNS-7010100')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNSG', N'NON CNS GY 7013600')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNSN', N'NON CNS 7012200')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'ILS', N'Bill outside CTIS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'NILS', N'Bill inside CTIS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'RT', N'ผู้ค้าปลีก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'WO', N'ผุ้ค่าส่ง')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FD', N'FORM D')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FR', N'FORM CO')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FT', N'FORM FTA')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'01', N'JOB CONFIRMED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'02', N'JOB IN PROCESS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'03', N'CLEARANCE COMPLETED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'04', N'READY FOR BILLING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'05', N'PARTIAL BILLING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'06', N'BILLING COMPLETED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'07', N'PAYMENT COMPLETED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'98', N'HOLD FOR CHECKING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'99', N'CANCELLED')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Approve', N'ปรับปรุงสถานะงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'CreateJob', N'เปิดงานใหม่')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Index', N'ค้นหางาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'ShowJob', N'รายละเอียดงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Transport', N'ใบจองรถ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'TruckApprove', N'อนุมัติงานขนส่ง')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'TransportRoute', N'เส้นทางการขนส่งสินค้า')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PRD', N'AUTHOR_NAME', N'น.ส.ธิดารัตน์ ปัจจัยสมบูรณ์')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PRD', N'AUTHOR_POSITION', N'Manager Customs Brokerage')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS1', N'3195/8 อาคารวิบูลย์ธานี 1 ชั้น 3 ถนนพระราม 4')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS1_EN', N'3195/8  Vibulthani Tower 1.3rd floor, Rama 4 Road,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS2', N'แขวงคลองตัน เขตคลองเตย กรุงเทพมหานคร 10110')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS2_EN', N'Klongton,Klongtoey,Bangkok 10110')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_EMAIL', N'www.apllogistics.com')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_FAX', N'(66)(2) 080-9009-10')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_LOGO', N'apl-logo.jpg')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_NAME', N'บริษัท เอพีแอล โลจิสติคส์ เอสวีซีเอส (ประเทศไทย) จำกัด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_NAME_EN', N'APL LOGISTICS SVCS (THAILAND) CO.,LTD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXBRANCH', N'00000')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXNUMBER', N'0105542016277')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TEL', N'(66)(2) 080-9000')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'CURRENCY', N'THB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_BRANCH', N'00')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_LANGUAGE', N'EN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'PAYMENT_CREDIT_DAYS', N'30')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'SAVE_LOG', N'N')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'VATRATE', N'0.07')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_CLITERIA', N'WHERE,c.ClrDate,c.CustCode,j.JNo,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_SQL', N'SELECT j.CustCode,c.ClrNo,c.ClrDate,c.JobNo,c.SDescription,c.VenderCode,c.AmtCostClear+c.AmtCostUnClear+c.AmtCostSlip+c.AmtCostNoSlip+c.CostVat as TotalExpClear,
c.AmtCostSlip,c.AmtCostNoSlip,c.CostVat as TotalVAT,c.CostTax as TotalWHT,c.AmtCostClear as ''BILLED'',c.AmtCostUnClear as ''UNBILLED'',
c.RefNo,c.PaymentDate,c.SlipNo
FROM (
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
d.AdvNO as RefNo,a.PaymentDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_AdvHeader a ON d.BranchCode=a.BranchCode AND d.AdvNO=a.AdvNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND NOT isnull(a.CancelProve,'''')<>'''' AND d.AdvNO<>''''
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
d.VenderBillingNo as RefNo,a.PaymentDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_PaymentHeader a ON d.BranchCode=a.BranchCode AND SUBSTRING(d.VenderBillingNo,1,13)=a.DocNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND ISNULL(d.VenderBillingNo,'''')<>''''
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
h.ClrNo as RefNo,h.ReceiveDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND ISNULL(d.VenderBillingNo,'''')='''' AND ISNULL(d.AdvNO,'''')=''''
) c LEFT JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'ReportNameEN', N'Account Payable Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'ReportNameTH', N'รายงานค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_CLITERIA', N'WHERE,c.ClrDate,c.CustCode,j.JNo,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_SQL', N'SELECT j.CustCode,c.ClrNo,c.ClrDate,c.JobNo,c.SDescription,c.SlipNo,c.VenderCode,c.AmtCharge as TotalCharge,c.Amt,
c.AmtVat,c.AmtWht as TotalWHT,c.InvoiceNo,c.AmtChargeBill as BILLED,c.AmtChargeUnBill as UNBILLED
 FROM (
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from Job_ClearDetail d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_AdvHeader a ON d.BranchCode=a.BranchCode AND d.AdvNO=a.AdvNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
UNION
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from (select *,SUBSTRING(VenderBillingNo,0,CHARINDEX(''#'',VenderBillingNo,0)) as VenderInvNo from Job_ClearDetail) d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_PaymentHeader a ON d.BranchCode=a.BranchCode AND d.VenderInvNo=a.DocNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from Job_ClearDetail d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
AND ISNULL(d.AdvNo,'''')='''' AND ISNULL(d.VenderBillingNo,'''')=''''
) c LEFT JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'ReportNameEN', N'Account Receiable Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'ReportNameTH', N'รายงานรายได้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_CLITERIA', N'WHERE,t.AdvDate, t.CustCode, t.ForJNo, t.AdvBy, t.ForwarderCode, t.AdvStatus, t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_SQL', N'SELECT t.DocDate as JobDate,t.ForJNo as JobNo,t.HAWB,t.AgentCode,t.ETADate,t.DutyDate,t.JobTypeName,t.ShipByName,t.AdvBy,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t {0} ORDER BY t.DocDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'ReportNameEN', N'Advance Clearing Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'ReportNameTH', N'รายงานการติดตามใบเบิก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_CLITERIA', N'AND,a.AdvDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_SQL', N'SELECT ad.AdvNo,ad.AdvDate,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,
ad.BaseAmount as Amount,ad.ChargeVAT as TotalVAT,
ad.AdvPayAmount as TotalAdvance,ad.Charge50Tavi as TotalWHT, 
(CASE WHEN ad.PaymentRef<>'''' THEN ad.AdvPayAmount ELSE 0 END) as ''Advance Paid''
FROM (
select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order 
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo WHERE a.DocStatus<>99 {0}
) ad  ORDER BY ad.AdvDate,ad.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'ReportNameEN', N'Advance Payment')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'ReportNameTH', N'รายงานการจ่ายเงินเบิกล่วงหน้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,d.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_SQL', N'select j.DocDate,j.JNo,b.NameEng as Customer,j.HAWB,jt.JobTypeName,sb.ShipByName,
a.PaymentDate,a.PaymentRef,v.acType,p.BookCode,bk.BookName,a.AdvBy,a.AdvDate,a.AdvNo,
d.SDescription,d.AdvPayAmount as PaidAmount,d.Charge50Tavi as ''TotalWHT'',p.ChqDate,p.ChqNo
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN  dbo.Job_Order j on d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
INNER JOIN (SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt
ON j.JobType=jt.JobType
INNER JOIN (SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') sb
ON j.ShipBy=sb.ShipBy
LEFT JOIN Job_CashControlDoc v ON a.BranchCode=v.BranchCode AND a.PaymentRef=v.ControlNo AND v.DocType=''ADV''
LEFT JOIN Job_CashControlSub p ON v.BranchCode=p.BranchCode AND v.ControlNo=p.ControlNo AND v.acType=p.acType
LEFT JOIN Mas_BookAccount bk ON p.BranchCode=bk.BranchCode AND p.BookCode=bk.BookCode
WHERE a.DocStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'ReportNameEN', N'Advance Expenses Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'ReportNameTH', N'รายงานการเบิกค่าใช้จ่ายแต่ละประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_SQL', N'SELECT e.NameEng as ''Customer'',i.NameEng as ''Consignee'',
c.InvProduct as ''Products'',c.TotalContainer as ''Containers'',
c.BookingNo as ''Booking'',
c.HAWB as ''BL/AWB'',c.CSCode as ''CS'',v.TName as ''Vender'',
b.ForJNo as ''Job Number'',c.DeclareNumber as ''Customs Declare'',
c.DocDate as ''Job Date'',
SUM(CASE WHEN b.SICode='''' THEN b.AdvNet ELSE 0 END) as ''(N/A)'',SUM(CASE WHEN b.SICode=''ADV-001'' THEN b.AdvNet ELSE 0 END) as ''ค่าภาษีอากร'',SUM(CASE WHEN b.SICode=''ADV-019'' THEN b.AdvNet ELSE 0 END) as ''ค่า ฺB/L'',SUM(CASE WHEN b.SICode=''ERN-001'' THEN b.AdvNet ELSE 0 END) as ''ค่ามัดจำตู้'',
SUM(b.AdvNet) as ''Advance Paid'',a.EmpCode as ''Request By'',
SUM(d.ClrNet) as ''Clearing'',c.CloseJobDate as ''Close Job Date''
FROM Job_AdvDetail b
INNER JOIN Job_AdvHeader a ON b.BranchCode=a.BranchCode 
AND b.AdvNo= a.AdvNo
INNER JOIN Job_Order c ON b.BranchCode=c.BranchCode
AND b.ForJNo=c.JNo
INNER JOIN Mas_Company e ON e.CustCode=c.CustCode AND e.Branch=c.CustBranch
LEFT JOIN (Select CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng from Mas_Company Group by CustCode) i ON i.CustCode=c.CustCode 
LEFT JOIN (
    SELECT ch.BranchCode,cd.AdvNo,cd.AdvItemNo,SUM(cd.BNet) as ClrNet
    FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd
    ON ch.BranchCode=cd.BranchCode AND 
    ch.ClrNo=cd.ClrNo
    WHERE ch.DocStatus<>99
    GROUP BY ch.BranchCode,cd.AdvNo,cd.AdvItemNo
) d
ON b.BranchCode=d.BranchCode
AND b.AdvNo=d.AdvNo
AND b.ItemNo=d.AdvItemNo
LEFT JOIN Mas_Vender on c.ForwarderCode=v.VenCode
WHERE a.DocStatus<>99 AND b.AdvNet>0 {0}
GROUP BY e.NameEng,i.NameEng,c.InvProduct,c.TotalContainer,c.BookingNo,c.HAWB,
c.CSCode,v.TName,b.ForJNo,c.DeclareNumber,c.DocDate,a.EmpCode,c.CloseJobDate
ORDER BY e.NameEng,b.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'ReportNameEN', N'Advance Total Expense Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'ReportNameTH', N'รายงานสรุปการเบิกแต่ละประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'ReportType', N'FIX')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_CLITERIA', N'AND,t.ETDDate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=2 AND t.JobStatus<>99  {0} ORDER BY t.ETDDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'ReportNameEN', N'Advance Export Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'ReportNameTH', N'รายงานรายละเอียดใบเบิกขาออก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_CLITERIA', N'AND,t.ETADate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETADate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0}  ORDER BY t.ETADate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'ReportNameEN', N'Advance Import Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'ReportNameTH', N'รายงานรายละเอียดใบเบิกขาเข้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'MAIN_CLITERIA', N'AND,t.ETDDate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType>2 AND t.JobStatus<>99  {0} ORDER BY t.ETDDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'ReportNameEN', N'Advance Local Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'ReportNameTH', N'รายงานรายละเอียดใบเบิกอื่นๆ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_SQL', N'select a.AdvNo,a.EmpCode,c.CustCode,c.NameThai as CustName,b.ForJNo as JobNo,
j.DutyDate as InspectionDate,a.PaymentDate,a.PaymentRef,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt,st.AdvStatusName
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
	SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
inner join Job_Order j ON b.BranchCode=j.BranchCode AND b.ForJNo=j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as AdvStatus, ConfigValue as AdvStatusName FROM Mas_Config WHERE ConfigCode=''ADV_STATUS''
) st ON a.DocStatus=st.AdvStatus
WHERE a.DocStatus<>99 {0}
GROUP BY a.AdvNo,a.EmpCode,c.CustCode,c.NameThai,b.ForJNo,
j.DutyDate,a.PaymentDate,a.PaymentRef,e.ReceiveRef,e.PaidAmount,st.AdvStatusName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'ReportNameEN', N'Advance Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'ReportNameTH', N'รายงานสรุปใบเบิกค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVTOTAL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVTOTAL', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVTOTAL', N'ReportNameEN', N'Details of Advance Payment By Job Order')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVTOTAL', N'ReportNameTH', N'รายงานการเบิกค่าใช้จ่ายแยกตามประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVTOTAL', N'ReportType', N'FIX')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_CLITERIA', N'AND,h.DocDate,,,h.EmpCode,h.VenCode,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_SQL', N'SELECT h.DocNo, h.DocDate, v.TName, h.PoNo, h.RefNo, 
CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as PaidAmount,
CASE WHEN NOT ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as UnPaidAmount,
h.PaymentRef
FROM dbo.Job_PaymentHeader AS h LEFT JOIN dbo.Mas_Vender AS v ON h.VenCode = v.VenCode
WHERE NOT (ISNULL(h.CancelProve,'''')<>'''') {0} ORDER BY v.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'ReportNameEN', N'Accrue Expense Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'ReportNameTH', N'รายงานเจ้าหนี้คงค้าง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_CLITERIA', N'AND,ph.DocDate,jd.CustCode,jd.JNo,jd.CSCode,ph.VenCode,jd.JobStatus,ph.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_SQL', N'SELECT ph.DocNo,ph.DocDate, ph.VenCode, ph.RefNo, pd.ForJNo, pd.SDescription, ph.PaymentRef, pd.Total as TotalNet,pd.BookingRefNo, pd.ClrRefNo, cd.LinkBillNo, jd.CustCode, jd.DeclareNumber, jd.CSCode
FROM dbo.Job_PaymentHeader AS ph INNER JOIN dbo.Job_PaymentDetail AS pd ON ph.BranchCode = pd.BranchCode AND ph.DocNo = pd.DocNo LEFT JOIN dbo.Job_LoadInfoDetail AS ld ON pd.BookingItemNo = ld.ItemNo AND pd.BookingRefNo = ld.BookingNo AND pd.BranchCode = ld.BranchCode LEFT OUTER JOIN dbo.Job_Order AS jd ON pd.ForJNo = jd.JNo AND pd.BranchCode = jd.BranchCode LEFT OUTER JOIN dbo.Job_ClearDetail AS cd ON pd.ClrItemNo = cd.ItemNo AND pd.ClrRefNo = cd.ClrNo AND pd.BranchCode = cd.BranchCode WHERE (ISNULL(ph.CancelProve, '''') = '''') {0} ORDER BY ph.VenCode,ph.RefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'ReportNameEN', N'Billing Expense Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'ReportNameTH', N'รายงานบิลค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'MAIN_SQL', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,ctn.FactoryDate,ctn.FactoryTime,ctn.LoadDate,ctn.Remark,j.TotalGW,ctn.VenderCode,j.AgentCode,
j.BookingNo,ctn.CYPlace,ctn.FactoryPlace,ctn.PackingPlace,ctn.ReturnPlace,ctn.CYDate,ctn.CYTime,j.ETDDate,j.VesselName,j.MAWB,
j.InvNo,j.DeclareNumber,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,
cl.[CLEARANCE],cl.[NEXT PAGES],cl.[FORM],cl.[FUMIGATE],ctn.EstimateAmt [TRANSPORTATION],cl.[EXTRA],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[FORM FEE],cl.[CHAMBER FEE],cl.[FTI CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.[B/L],cl.[DEM/DET],cl.[B-OTHERS],cl.[REIM TTL],cl.[TOTAL AMOUNT],
cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[B/L FEE],cl.[SURRENDER],cl.[FREIGHT],cl.[BUNKER],cl.[SEAL],cl.[HANDLING FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvCountry=ct.CTYCODE
left join 
(SELECT a.BranchCode,a.JNo,a.BookingNo,
b.VenderCode,b.FactoryDate,b.FactoryTime,b.LoadDate,b.Remark,b.CYPlace,b.FactoryPlace,
b.PackingPlace,b.ReturnPlace,b.CYDate,b.CYTime,
SUM(CASE WHEN a.CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN a.CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN a.CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN a.CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN a.CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN a.CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont'',SUM(CASE WHEN p.ChargeCode NOT in(''R-SVT-007'',''R-SNT-007'') AND p.ChargeCode Like ''R-S_T%'' THEN p.ChargeAmount ELSE 0 END) as ''EstimateAmt''
FROM Job_LoadInfoDetail a LEFT JOIN Job_LoadInfo b
ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingNo AND a.JNo=b.JNo
LEFT JOIN Job_TransportPrice p ON a.BranchCode=p.BranchCode AND 
a.LocationID=p.LocationID AND b.VenderCode=p.VenderCode AND b.NotifyCode=p.CustCode
WHERE a.CauseCode<>''99''
GROUP BY a.BranchCode,a.JNo,a.BookingNo,b.VenderCode,b.FactoryDate,b.FactoryTime,b.LoadDate,b.Remark,b.CYPlace,b.FactoryPlace,
b.PackingPlace,b.ReturnPlace,b.CYDate,b.CYTime
) ctn on j.BranchCode=ctn.BranchCode AND j.BookingNo=ctn.BookingNo AND j.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode in(''R-SVD-001'',''R-SVD-002'',''R-SVD-003'') THEN d.UsedAmount ELSE 0 END) as ''FORM'',
SUM(CASE WHEN d.SICode in(''R-SVG-004'') THEN d.UsedAmount ELSE 0 END) as ''FUMIGATE'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVG-003'') THEN d.UsedAmount ELSE 0 END) as ''EXTRA'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVG-004'',''R-SVG-003'',
''R-SVC-004'',''R-SVD-001'',''R-SVD-002'',''R-SVD-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FORM FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-014'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CHAMBER FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-033'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FTI CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-006'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B/L'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.SICode  NOT in(''B-ADV-006'',''B-ADV-024'',
''B-ADV-023'',''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'',''B-ADV-035'',''B-ADV-033'',''B-ADV-022'',''B-ADV-014'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''REIM TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
(CASE WHEN d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
(CASE WHEN d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
i.DocDate as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''B/L FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-054'') THEN d.UsedAmount ELSE 0 END) as ''SURRENDER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-049'') THEN d.UsedAmount ELSE 0 END) as ''SEAL'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-058'',''B-ADV-049''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-054'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',

SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo,d.LinkBillNo,i.DocDate
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType<>1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'MAIN_SQL_BACK', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,l.FactoryDate,l.FactoryTime,j.LoadDate,l.Remark,j.TotalGW,l.VenderCode,j.AgentCode,
j.BookingNo,l.CYPlace,l.FactoryPlace,l.PackingPlace,l.ReturnPlace,l.CYDate,l.CYTime,j.ETDDate,j.VesselName,j.MAWB,
j.InvNo,j.DeclareNumber,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,
cl.[CLEARANCE],cl.[NEXT PAGES],cl.[FORM],cl.[FUMIGATE],cl.[TRANSPORTATION],cl.[EXTRA],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[FORM FEE],cl.[CHAMBER FEE],cl.[FTI CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.[B/L],cl.[DEM/DET],cl.[B-OTHERS],cl.[REIM TTL],cl.[TOTAL AMOUNT],
cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[B/L FEE],cl.[SURRENDER],cl.[FREIGHT],cl.[BUNKER],cl.[SEAL],cl.[HANDLING FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvCountry=ct.CTYCODE
left join Job_LoadInfo l on j.BranchCode=l.BranchCode AND j.JNo=l.JNo and j.BookingNo=l.BookingNo
left join 
(SELECT BranchCode,JNo,BookingNo,
SUM(CASE WHEN CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont''
FROM Job_LoadInfoDetail
WHERE CauseCode<>''99''
GROUP BY BranchCode,JNo,BookingNo
) ctn on l.BranchCode=ctn.BranchCode AND l.BookingNo=ctn.BookingNo AND l.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode in(''R-SVD-001'',''R-SVD-002'',''R-SVD-003'') THEN d.UsedAmount ELSE 0 END) as ''FORM'',
SUM(CASE WHEN d.SICode in(''R-SVG-004'') THEN d.UsedAmount ELSE 0 END) as ''FUMIGATE'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVG-003'') THEN d.UsedAmount ELSE 0 END) as ''EXTRA'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVG-004'',''R-SVG-003'',
''R-SVC-004'',''R-SVD-001'',''R-SVD-002'',''R-SVD-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FORM FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-014'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CHAMBER FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-033'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FTI CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-006'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B/L'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.SICode  NOT in(''B-ADV-006'',''B-ADV-024'',
''B-ADV-023'',''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'',''B-ADV-035'',''B-ADV-033'',''B-ADV-022'',''B-ADV-014'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''REIM TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
(CASE WHEN d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
(CASE WHEN d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
i.DocDate as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''B/L FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-054'') THEN d.UsedAmount ELSE 0 END) as ''SURRENDER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-049'') THEN d.UsedAmount ELSE 0 END) as ''SEAL'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-058'',''B-ADV-049''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-054'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',

SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo,d.LinkBillNo,i.DocDate
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType<>1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'ReportNameEN', N'Job Export Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'ReportNameTH', N'รายงานสรุปการทำงานขาออก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'MAIN_SQL', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,j.VesselName,j.ClearPortNo,ctn.PickupPlace,j.ETADate,j.LoadDate,ctn.DeliveryPlace,
j.ClearDate,j.EstDeliverDate,j.AgentCode,j.MAWB,j.HAWB,j.BookingNo,j.ImExDate,ctn.FactoryDate,ctn.FactoryTime,ctn.ContactName,
ctn.Remark,ctn.VenderCode,ctn.ReturnPlace,j.InvNo,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,j.DeclareNumber,j.DutyAmount,j.DutyDate,
cl.[CLEARANCE],cl.[2++],cl.[NEXT PAGES],ctn.EstimateAmt [TRANSPORTATION],cl.[CHARSIS],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[CUSTOMS DUTY],cl.[D/O FEE],cl.[PORT CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.DEMURRAGE,cl.DETENSION,cl.[DAMAGE],cl.[B-OTHERS],cl.[B-TTL],
cl.[TOTAL AMOUNT],cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[BL FEE],cl.[HANDLING FEE],cl.[FREIGHT],cl.[BUNKER],cl.[DEM/DET],cl.[CLEANING FEE],cl.[DAMAGE FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvFCountry=ct.CTYCODE
left join 
(SELECT a.BranchCode,a.JNo,a.BookingNo,
b.VenderCode,b.FactoryDate,b.FactoryTime,b.LoadDate,b.Remark,b.CYPlace,b.FactoryPlace,
b.PackingPlace,b.CYDate,b.CYTime,b.ContactName,
SUM(CASE WHEN a.CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN a.CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN a.CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN a.CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN a.CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN a.CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont'',
SUM(CASE WHEN p.ChargeCode NOT in(''R-SVT-007'',''R-SNT-007'') AND p.ChargeCode Like ''R-S_T%'' THEN p.ChargeAmount ELSE 0 END) as ''EstimateAmt'',
MAX(a.PlaceName1) as PickupPlace,
MAX(a.PlaceName2) as DeliveryPlace,
MAX(a.PlaceName3) as ReturnPlace
FROM Job_LoadInfoDetail a LEFT JOIN Job_LoadInfo b
ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingNo AND a.JNo=b.JNo
LEFT JOIN Job_TransportPrice p ON a.BranchCode=p.BranchCode AND 
a.LocationID=p.LocationID AND b.VenderCode=p.VenderCode AND b.NotifyCode=p.CustCode
WHERE a.CauseCode<>''99''
GROUP BY a.BranchCode,a.JNo,a.BookingNo,
b.VenderCode,b.FactoryDate,b.FactoryTime,b.LoadDate,b.Remark,b.CYPlace,b.FactoryPlace,
b.PackingPlace,b.CYDate,b.CYTime,b.ContactName
) ctn on j.BranchCode=ctn.BranchCode AND j.BookingNo=ctn.BookingNo AND j.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-003'') THEN d.UsedAmount ELSE 0 END) as ''2++'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVT-007'',''R-SNT-007'') THEN d.UsedAmount ELSE 0 END) as ''CHARSIS'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVT-007'',''R-SNT-007'',
''R-SVC-004'',''R-SVC-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-018'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS DUTY'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''D/O FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-044'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''PORT CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEMURRAGE'',
SUM(CASE WHEN d.SICode in(''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DETENSION'',
SUM(CASE WHEN d.SICode in(''B-ADV-048'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DAMAGE'',
SUM(CASE WHEN d.SICode NOT in(''B-ADV-048'',''B-ADV-024'',''B-ADV-041'',''B-ADV-015'',
''B-ADV-023'',''B-ADV-039'',''B-ADV-040'',''B-ADV-035'',''B-ADV-044'',''B-ADV-022'',''B-ADV-018'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
(CASE WHEN d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
(CASE WHEN d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
i.DocDate as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''BL FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-015'') THEN d.UsedAmount ELSE 0 END) as ''CLEANING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-048'') THEN d.UsedAmount ELSE 0 END) as ''DAMAGE FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-048'',''B-ADV-015'',''B-ADV-023'',''B-ADV-024''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-058'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo,d.LinkBillNo,i.DocDate
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType=1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'MAIN_SQL_BACK', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,j.VesselName,j.ClearPortNo,ctn.PickupPlace,j.ETADate,j.LoadDate,ctn.DeliveryPlace,
j.ClearDate,j.EstDeliverDate,j.AgentCode,j.MAWB,j.HAWB,j.BookingNo,j.ImExDate,l.FactoryDate,l.FactoryTime,l.ContactName,
l.Remark,l.VenderCode,ctn.ReturnPlace,j.InvNo,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,j.DeclareNumber,j.DutyAmount,j.DutyDate,
cl.[CLEARANCE],cl.[2++],cl.[NEXT PAGES],cl.[TRANSPORTATION],cl.[CHARSIS],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[CUSTOMS DUTY],cl.[D/O FEE],cl.[PORT CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.DEMURRAGE,cl.DETENSION,cl.[DAMAGE],cl.[B-OTHERS],cl.[B-TTL],
cl.[TOTAL AMOUNT],cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[BL FEE],cl.[HANDLING FEE],cl.[FREIGHT],cl.[BUNKER],cl.[DEM/DET],cl.[CLEANING FEE],cl.[DAMAGE FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvFCountry=ct.CTYCODE
left join Job_LoadInfo l on j.BranchCode=l.BranchCode AND j.JNo=l.JNo and j.BookingNo=l.BookingNo
left join 
(SELECT BranchCode,JNo,BookingNo,
SUM(CASE WHEN CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont'',
MAX(PlaceName1) as PickupPlace,
MAX(PlaceName2) as DeliveryPlace,
MAX(PlaceName3) as ReturnPlace
FROM Job_LoadInfoDetail
WHERE CauseCode<>''99''
GROUP BY BranchCode,JNo,BookingNo
) ctn on l.BranchCode=ctn.BranchCode AND l.BookingNo=ctn.BookingNo AND l.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-003'') THEN d.UsedAmount ELSE 0 END) as ''2++'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVT-007'',''R-SNT-007'') THEN d.UsedAmount ELSE 0 END) as ''CHARSIS'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVT-007'',''R-SNT-007'',
''R-SVC-004'',''R-SVC-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-018'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS DUTY'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''D/O FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-044'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''PORT CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEMURRAGE'',
SUM(CASE WHEN d.SICode in(''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DETENSION'',
SUM(CASE WHEN d.SICode in(''B-ADV-048'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DAMAGE'',
SUM(CASE WHEN d.SICode NOT in(''B-ADV-048'',''B-ADV-024'',''B-ADV-041'',''B-ADV-015'',
''B-ADV-023'',''B-ADV-039'',''B-ADV-040'',''B-ADV-035'',''B-ADV-044'',''B-ADV-022'',''B-ADV-018'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
(CASE WHEN d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
(CASE WHEN d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
i.DocDate as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''BL FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-015'') THEN d.UsedAmount ELSE 0 END) as ''CLEANING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-048'') THEN d.UsedAmount ELSE 0 END) as ''DAMAGE FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-048'',''B-ADV-015'',''B-ADV-023'',''B-ADV-024''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-058'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo,d.LinkBillNo,i.DocDate
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType=1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'ReportNameEN', N'Job Import Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'ReportNameTH', N'รายงานสรุปการทำงานขาเข้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_CLITERIA', N'WHERE,t.DocDate,t.CustCode,t.RefNo,t.EmpCode,,,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_SQL', N'SELECT CustCode,DocNo,DocDate,DueDate,RefNo,
Sum(AmtAdvance) as TotalAdv,Sum(AmtCharge) as TotalCharge,Sum(CASE WHEN AmtCharge>0 THEN AmtVAT ELSE 0 END) as TotalVat,
Sum(CASE WHEN AmtCharge>0 THEN Amt50Tavi ELSE 0 END) as Total50Tavi,
Sum(TotalAmt) as TotalNet,Sum(TotalReceiveAmt) as TotalReceived,Sum(TotalCreditAmt) as TotalCredit,Sum(TotalBal) as TotalBal
FROM (
SELECT ih.*,id.SICode,id.SDescription,id.AmtCharge,id.AmtVat,id.Amt50Tavi,id.AmtAdvance,
id.TotalAmt,id.AmtCredit,ISNULL(c.TotalCredit,0) as TotalCreditAmt,id.AmtCredit+ISNULL(r.RecvNet,0) as TotalReceiveAmt
,id.TotalAmt-id.AmtCredit-ISNULL(c.TotalCredit,0)-ISNULL(r.RecvNet,0) as TotalBal
,r.FromReceiptNo,r.VoucherNo,r.ReceiptDate
FROM dbo.Job_InvoiceHeader AS ih INNER JOIN dbo.Job_InvoiceDetail AS id 
ON ih.BranchCode = id.BranchCode AND ih.DocNo=id.DocNo
LEFT JOIN (SELECT    cd.BranchCode, cd.BillingNo, cd.BillItemNo, SUM(cd.TotalNet) AS TotalCredit
FROM dbo.Job_CNDNHeader AS ch INNER JOIN dbo.Job_CNDNDetail AS cd 
ON ch.BranchCode = cd.BranchCode AND ch.DocNo = cd.DocNo
WHERE (ch.DocStatus <> 99)
GROUP BY cd.BranchCode, cd.BillingNo, cd.BillItemNo) as c
ON id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
LEFT JOIN (SELECT    rd.BranchCode, rd.InvoiceNo, rd.InvoiceItemNo, 
SUM(rd.Net) AS RecvNet,
(SELECT STUFF((
SELECT DISTINCT '','' + ReceiptNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as FromReceiptNo,
(SELECT STUFF((
SELECT DISTINCT '','' + VoucherNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as VoucherNo,
MAX(rh.ReceiptDate) as ReceiptDate
FROM      dbo.Job_ReceiptHeader AS rh INNER JOIN
             dbo.Job_ReceiptDetail AS rd ON rh.BranchCode = rd.BranchCode AND rh.ReceiptNo = rd.ReceiptNo
WHERE    (NOT (ISNULL(rh.CancelProve, '''') <> ''''))
GROUP BY rd.InvoiceNo, rd.InvoiceItemNo, rd.BranchCode) as r
ON id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
WHERE    (NOT (ISNULL(ih.CancelProve, '''') <> ''''))
) t {0} GROUP BY CustCode,DocNo,DocDate,DueDate,RefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'ReportNameEN', N'Accrue Income Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'ReportNameTH', N'รายงานลูกหนี้คงเหลือ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'MAIN_CLITERIA', N'WHERE,,,,,,,,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'MAIN_SQL', N'select u.TName,a.*,c.ConfigValue as ModuleName 
from Mas_UserAuth a inner join Mas_User u
on a.UserID=u.UserID
left join Mas_Config c ON a.AppID=c.ConfigCode AND a.MenuID=c.ConfigKey
where u.UserID<>''ADMIN''
order by u.TName,a.MenuID')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'ReportGroup', N'MAS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'ReportNameEN', N'User Authorized Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'ReportNameTH', N'รายการสิทธิผู้ใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_AUTHORIZE', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_CLITERIA', N'AND,h.BillDate,h.CustCode,,h.EmpCode,,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_SQL', N'SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal 
FROM (
SELECT h.BranchCode, h.BillAcceptNo, h.BillDate, h.CustCode, h.CustBranch, h.BillRecvBy, h.BillRecvDate, h.DuePaymentDate, h.BillRemark, h.CancelReson, 
h.CancelProve, h.CancelDate, h.CancelTime, h.EmpCode, h.RecDateTime, h.TotalCustAdv, h.TotalAdvance, h.TotalChargeVAT, h.TotalChargeNonVAT, h.TotalVAT, 
h.TotalWH, h.TotalDiscount, h.TotalNet, d.ItemNo, d.InvNo, i.AmtAdvance, i.AmtChargeNonVAT, i.AmtChargeVAT, i.AmtWH, i.AmtVAT, i.AmtTotal, d.CurrencyCode, 
d.ExchangeRate, d.AmtCustAdvance, d.AmtForeign, d.InvDate, d.RefNo, d.AmtVATRate, d.AmtWHRate, d.AmtDiscount, d.AmtDiscRate
FROM dbo.Job_BillAcceptHeader AS h INNER JOIN
dbo.Job_BillAcceptDetail AS d ON h.BranchCode = d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo 
INNER JOIN (
	SELECT a.BranchCode,a.DocNo,SUM(b.AmtAdvance) as AmtAdvance,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT>0 THEN b.AmtCharge ELSE 0 END) as AmtChargeVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT=0 THEN b.AmtCharge ELSE 0 END) as AmtChargeNonVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT>0 THEN b.AmtVat ELSE 0 END) as AmtVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.Amt50Tavi>0 THEN b.Amt50Tavi ELSE 0 END) as AmtWH,
	SUM(b.TotalAmt) as AmtTotal
	FROM Job_InvoiceHeader a INNER JOIN Job_InvoiceDetail b
	ON a.BranchCode=b.BranchCode AND a.DocNo=b.DocNo
        WHERE ISNULL(a.CancelProve,'''')=''''
	GROUP BY a.BranchCode,a.DocNo
) i ON d.BranchCode=i.BranchCode AND d.InvNo=i.DocNo
WHERE ISNULL(h.CancelProve,'''')='''' {0}
) bl ORDER BY bl.BillDate,bl.BillAcceptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'ReportGroup', N'INV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'ReportNameEN', N'Billing Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'ReportNameTH', N'รายงานใบวางบิลประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_CLITERIA', N'AND,,,,b.RecUser,,,b.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_SQL', N'SELECT bk.BookCode,ISNULL(bk.BookName,''N/A'') as BookName,bk.ControlBalance as ''Floating Fund'',bk.ControlBalance-bk.SumBal as Used,bk.SumBal as 
TotalBalance FROM (
SELECT q.*,q.SumCashOnhand+q.SumChqClear as SumCash,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand-q.LimitBalance as SumCashInBank,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand+q.SumCredit as SumBal,
q.SumCredit+q.SumChqReturn as SumCreditable
FROM (
select c.BookCode,c.BookName,c.LimitBalance,c.ControlBalance,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount) else a.CashAmount end) as SumCashOnhand,
Sum(Case when a.ChqStatus=''P'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqClear,
Sum(Case when a.ChqStatus=''R'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqReturn,
Sum(Case when a.ChqStatus NOT IN(''P'',''R'') then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqOnhand,
Sum(Case when a.PRType=''P'' then -1*a.CreditAmount else a.CreditAmount end) as SumCredit,
Sum(Case when a.PRType=''P'' then -1*(a.CreditAmount) else 0 end) as SumAP,
Sum(Case when a.PRType=''R'' then (a.CreditAmount) else 0 end) as SumAR,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount+a.ChqAmount) else 0 end) as SumPV,
Sum(Case when a.PRType=''R'' then (a.CashAmount+a.ChqAmount) else 0 end) as SumRV
from Job_CashControlSub a inner join Job_CashControl b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo
left join Mas_BookAccount c 
on a.BookCode=c.BookCode
WHERE ISNULL(b.CancelProve,'''')='''' AND a.PRType<>'''' 
group by c.BookCode,c.BookName,c.LimitBalance,c.ControlBalance) q
) bk ORDER BY BookCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'ReportNameEN', N'Book Accounts Balance')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'ReportNameTH', N'รายงานการใช้จ่ายเงินตามสมุดบัญชี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_CLITERIA', N'AND,,d.CustCode,,,d.VenderCode,,d.BranchCode,d.SICode,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_SQL', N'select h.LocationRoute as WorkType,d.VenderCode,d.CustCode,d.SDescription as CostName,d.CostAmount,s.NameThai as ChargeName ,d.ChargeAmount,
d.ChargeAmount-d.CostAmount as Profit
from Job_TransportPrice d inner join Job_TransportRoute h
ON d.LocationID=h.LocationID
left join Job_SrvSingle s 
ON d.ChargeCode=s.SICode
left join Mas_Company c
ON d.CustCode=c.CustCode 
WHERE h.IsActive=1 AND c.Branch=0
{0}
ORDER BY d.SDescription,d.ChargeAmount-d.CostAmount DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'ReportNameEN', N'Buy Rates By Broker')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'ReportNameTH', N'รายงานการเปรียบเทียบราคาต้นทุนแต่ละผู้ให้บริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.BookCode,h.RecUser,,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_SQL', N'SELECT BookCode,acType,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount)*-1 ELSE (CashAmount+ChqAmount) END) as TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) AND d.PRType<>'''' {0}
) as t ORDER BY BookCode,acType,VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'ReportNameEN', N'Financial Balance')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'ReportNameTH', N'รายงานสรุปการรับจ่ายเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.BookCode,h.RecUser,,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_SQL', N'SELECT BookCode,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount+CreditAmount) ELSE 0 END) as PaidAmount,
(CASE WHEN PRType=''P'' THEN 0 ELSE (CashAmount+ChqAmount+CreditAmount) END) as TotalReceived,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE d.PRType<>'''' AND ISNULL(h.CancelProve,'''')='''' {0}
) as t ORDER BY VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'ReportNameEN', N'Cash Flow')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'ReportNameTH', N'รายงานงบกระแสเงินสด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_CLITERIA', N'AND,b.VoucherDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,ControlNo,VoucherDate,DocUsed,AmountUsed,AmountRemain,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'ReportNameEN', N'Cheque Customer Payment')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'ReportNameTH', N'รายงานการจ่ายเช็คของลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,DocUsed,AmountUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.BankCode,h.BankBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.BankCode,h.BankBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.BankCode,h.BankBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch 
WHERE a.acType=''CH'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'ReportNameEN', N'Cashier Cheque Issue')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'ReportNameTH', N'รายงานการจ่ายเช็คประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,AmountUsed,AmountRemain,DocUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU''
AND a.PRType=''R'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' {0}
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'ReportNameEN', N'Cheque Customer Receive')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'ReportNameTH', N'รายงานการรับเช็คประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_CLITERIA', N'AND,h.ClrDate,j.CustCode,j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvNet as TotalAdvance,cl.ClrNet as TotalExpClear,cl.Tax50Tavi as TotalWHT,cl.SlipNo,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl ORDER BY cl.ClrDate,cl.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'ReportGroup', N'CLR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'ReportNameEN', N'Clearing Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'ReportNameTH', N'รายงานการปิดค่าใช้จ่ายประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.EmpCode,a.VenderCode,b.ClrStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_SQL', N'select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,d.NameThai as SDescription,a.VenderCode,a.Date50Tavi as SlipDate,a.UsedAmount,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as SumCharge,a.ChargeVAT as AmtVat,a.Tax50Tavi as Amt50Tavi,
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ''Invoice Billed'',
(CASE WHEN NOT ISNULL(a.LinkBillNo,'''')<>'''' AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as TotalBalance,a.LinkBillNo
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where b.DocStatus<>99 {0}
    order by a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'ReportGroup', N'CLR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'ReportNameEN', N'Clearing Expenses Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'ReportNameTH', N'รายงานการปิดค่าใช้จ่ายตามประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_CLITERIA', N'AND,j.DutyDate,j.CustCode, j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,SUM(cl.UsedAmount) as UsedAmount,SUM(cl.ChargeVAT) as AmtVat,SUM(cl.Tax50Tavi) as TotalWHT,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=1 THEN cl.BNet ELSE 0 END) as SumAdvance,SUM(CASE WHEN cl.IsExpense=1 THEN cl.BNet ELSE 0 END) as SumCost,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=0 THEN cl.BNet ELSE 0 END) as SumCharge,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,j.DutyDate,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl WHERE cl.ClrNet > 0 GROUP BY cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,cl.LinkBillNo ORDER BY cl.ClrDate,cl.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'ReportGroup', N'CLR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'ReportNameEN', N'Clearing Summary Status')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'ReportNameTH', N'รายงานสรุปสถานะการปิดค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_CLITERIA', N'AND,a.DocDate,a.CustCode,,a.EmpCode,,,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_SQL', N'SELECT CustCode,DocDate,DocNo,InvoiceNo,TotalAmt as ''Amount'',TotalVAT,TotalWHT,TotalNet FROM (
SELECT a.*,b.InvoiceNo,
b.TotalAmt,b.TotalVAT,b.TotalWHT,b.TotalNet,b.FTotalNet
FROM Job_CNDNHeader a LEFT JOIN
(
    SELECT BranchCode,DocNo,
    (SELECT STUFF((
SELECT DISTINCT '','' + BillingNo
FROM Job_CNDNDetail WHERE BranchCode=d.BranchCode
AND DocNo=d.DocNo  
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as InvoiceNo,
    Sum(DiffAmt) as TotalAmt,
    Sum(VATAmt) as TotalVAT,
    Sum(WHTAmt) as TotalWHT,
    Sum(TotalNet) as TotalNet,
    Sum(ForeignNet) as FTotalNet
    FROM Job_CNDNDetail d
    GROUP BY BranchCode,DocNo
) b
ON a.BranchCode=b.BranchCode
AND a.DocNo=b.DocNo
 WHERE a.DocStatus<>99 AND ISNULL(a.ApproveBy,'''')<>'''' {0}) t ORDER BY CustCode,DocDate,DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'ReportNameEN', N'Credit/Debit Note Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'ReportNameTH', N'รายงานการปรับปรุงหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_SQL', N'select a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.DocStatus<99 AND a.AdvType=5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,e.ReceiveRef,e.PaidAmount
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'ReportNameEN', N'Credit Advance Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'ReportNameTH', N'รายงานสรุปใบทดรองจ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'MAIN_CLITERIA', N'WHERE,,,,,,,,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'MAIN_SQL', N'SELECT CustCode,Branch,TaxNumber,Title+''''+NameThai as TName ,NameEng as EName,TAddress1+''<br/>''+TAddress2 as TAddress,
EAddress1+''<br/>''+EAddress2 as EAddress,
Phone,FaxNumber,LoginName,LoginPassword,TermOfPayment,CreditLimit,BillCondition,GLAccountCode as ''CostCenter'',LnNO as ''SAPCustomerID'' 
FROM Mas_Company')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'ReportGroup', N'MAS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'ReportNameEN', N'Customer Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'ReportNameTH', N'รายชื่อลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTOMERS', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_CLITERIA', N'AND,c.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode, c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_SQL', N'SELECT CustCode,CustName,TAddress,COUNT(DISTINCT JNo) as ''Total Job'',
SUM(CostCleared) as TotalCost,SUM(Deposit) as TotalEarnest,
SUM(AdvBilled) as TotalAdv,SUM(ChargeBilled) as TotalCharge,
SUM(ChargeBilled)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,e.TAddress,e.EAddress1+''''+e.EAddress2 as EAddress,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.BNet ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=1 AND NOT d.GroupCode IN(''ERN'',''B-DEP'')  THEN a.BNet ELSE 0 END) as CostCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.BNet ELSE 0 END) as AdvBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.BNet ELSE 0 END) as ChargeBilled,
(CASE WHEN d.GroupCode IN(''ERN'',''B-DEP'') THEN a.BNet ELSE 0 END) as Deposit,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.BNet ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.BNet ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<90 {0}
) clr
GROUP BY CustCode,CustName,TAddress
ORDER BY CustCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'ReportNameEN', N'Customer Profit Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'ReportNameTH', N'รายงานสรุปกำไรขั้นต้นตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_CLITERIA', N'AND,c.LoadDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode,,e.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_SQL', N'SELECT CustCode,CustName,
SUM(AdvCleared+CostCleared) as TotalExpClear,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChgWaitBill) as TotalChargeWaitBill,
SUM(AdvCleared) as TotalAdv,SUM(ChargeCleared) as TotalCharge,SUM(CostCleared) as TotalCost,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
(CASE WHEN d.IsExpense=0 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ExpBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ChgWaitBill,
(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<>99 {0}
) clr
GROUP BY CustCode,CustName
ORDER BY CustName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'ReportNameEN', N'PNL By Customer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'ReportNameTH', N'รายงานสรุปกำไรขั้นต้นตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'COLUMN_SUM', N',Chq.Amt,TotalReceipt,TotalWhtax,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'MAIN_SQL', N'WITH rcv
AS 
(
select r.*,
CAST(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',0) as float) as CashAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',0) as CashBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',1) as CashRef,
CAST(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',0) as float) as ChqAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',0) as ChqBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',1),'';'',0) as ChqRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'';'',1),'':'',1) as BankChg
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.Remark,c.LnNO as CustNo,rh.CurrencyCode,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
rd.InvoiceNo as InvNo
from 
(
SELECT *,(CASE WHEN SUBSTRING(TRemark,1,2)=''CH'' THEN ''CASH;'' + TRemark ELSE TRemark END) as Remark 
FROM
Job_ReceiptHeader
WHERE ISNULL(CancelProve,'''')=''''
)
rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.Remark,rh.CancelProve
,c.LnNO,rh.CurrencyCode,rd.InvoiceNo
) r
)
SELECT rcv.CustNo,''CA'' as ''PayType'',RIGHT(''0''+CAST(Month(rcv.ReceiptDate) as varchar),2)+RIGHT(''0''+CAST(DAY(rcv.ReceiptDate) as varchar),2)+SUBSTRING(rcv.CustCode,1,2) as ''Chq.No'',
rcv.CashAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.CashAmount>0 AND SUBSTRING(rcv.CashRef,1,2)<>''TR'' 
UNION
SELECT rcv.CustNo,''WT'' as ''PayType'',RIGHT(''0''+CAST(Month(rcv.ReceiptDate) as varchar),2)+RIGHT(''0''+CAST(DAY(rcv.ReceiptDate) as varchar),2)+SUBSTRING(rcv.CustCode,1,2) as ''Chq.No'',
rcv.CashAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.CashAmount>0 AND SUBSTRING(rcv.CashRef,1,2)=''TR'' 
UNION
SELECT rcv.CustNo,''CK'' as ''PayType'',RIGHT(rcv.ChqRef,6) as ''Chq.No'',rcv.ChqAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.ChqAmount>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'ReportNameEN', N'SAP AR Payment Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'ReportNameTH', N'รายงานตัดรับชำระหนี้ SAP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'COLUMN_LENGTH', N'10,25,10,10,7,10,20')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_SQL', N'SELECT t.ReceiptNo as ''Receipt No'',CONCAT(t.CustEName,''<div style="display:flex;"><span style="flex:1">'',
(CASE WHEN t.CashAmount>''0.00'' THEN ''<br/>'' + t.CashRef ELSE '''' END),
(CASE WHEN t.ChqAmount>''0.00'' THEN ''<br/>'' + t.ChqRef ELSE '''' END),
''</span><span style="flex:1">'',
(CASE WHEN t.CashAmount>''0.00'' THEN ''<br/>'' + t.CashBank ELSE '''' END),
(CASE WHEN t.ChqAmount>''0.00'' THEN ''<br/>'' + t.ChqBank ELSE '''' END),
''</span></div>'') as ''Shipper/Cheque Details'',
t.ChqAmount as ''Chq Amt'',
t.CashAmount as ''Cash Amt'',
t.TotalWhtax as ''WHD Tax'',
Cast(t.ChqAmount as float)+Cast(t.CashAmount as float)+t.TotalWHTax as ''Total Amt'',t.InvNo as ''Invoice No''
FROM (
select r.*,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',0) as CashAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',0) as CashBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',1) as CashRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',0) as ChqAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',0) as ChqBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',1),'';'',0) as ChqRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'';'',1),'':'',1) as BankChg
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.Remark,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
rh.Total50Tavi as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from 
(
SELECT *,(CASE WHEN SUBSTRING(TRemark,1,2)=''CH'' THEN ''CASH;'' + TRemark ELSE TRemark END) as Remark 
FROM
Job_ReceiptHeader
WHERE ISNULL(CancelProve,'''')=''''
)
rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,rh.Total50Tavi,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.Remark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'ReportNameEN', N'Daily Cash')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'ReportNameTH', N'รายงานการรับเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'ReportType', N'APL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_CLITERIA', N'AND,a.Date50Tavi,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_SQL', N'select e.NameEng as ''Customer'',t.English as ''Agent'',
c.JNo as ''Job Number'',c.HAWB as ''AWB/BL No'',a.AdvNo as ''Advance No'',c.DutyDate as ''Inspection Date'',
b.ClrDate as ''Clearing Date'',c.TotalContainer as ''Container Number'',
a.SlipNO as ''Slip No'',a.Date50Tavi as ''Slip Date'',c.EstDeliverDate as ''Unload Date'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE DATEDIFF(day,GETDATE(),c.EstDeliverDate) END) as ''Days'',
a.AdvAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
ISNULL(a.LinkBillNo,'''') as ''Receipt#'',v.VoucherDate as ''Received Date''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
left join Mas_Vender t on c.ForwarderCode=t.VenCode
where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode IN(''ERN'',''B-DEP'') AND a.UsedAmount>0 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'ReportGroup', N'CLR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'ReportNameEN', N'Earnest Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'ReportNameTH', N'รายงานเงินมัดจำ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.ApproveDate,pa.VenCode,pa.PoNo,pa.RefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total as TotalNet,pa.PayType,pa.PaymentRef FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo 
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}
) pa ORDER BY pa.DocDate,pa.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'ReportNameEN', N'Bill-Expense Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'ReportNameTH', N'รายงานบิลค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.BookingRefNo,pa.ClrRefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total as TotalNet,pa.PayType,pa.PaymentDate,pa.PaymentRef,pa.ForJNo FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.PaymentDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo,d.ClrRefNo,d.BookingRefNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
WHERE ISNULL(h.CancelProve,'''')='''' {0}
) pa ORDER BY pa.SDescription,pa.DocDate,pa.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'ReportNameEN', N'Bill-Expense Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'ReportNameTH', N'รายงานบิลค่าใช้จ่ายแต่ละประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_CLITERIA', N'AND,c.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_SQL', N'select jt.JobTypeName as ''JobType'',sb.ShipByName as ''ShipBy'',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END) as ''Revenue'',
sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as ''Cost'',
count(DISTINCT c.JNo) as ''Total Job'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)/count(DISTINCT c.JNo)) as ''Average Revenue'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END)) as ''Profit'',
convert(decimal(10,2),(sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END))/count(DISTINCT c.JNo)) as ''Average Profit'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END)/count(DISTINCT c.JNo)) as ''Average Cost''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON c.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON c.ShipBy=sb.ShipBy
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<90 {0}
group by jt.JobTypeName,sb.ShipByName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'ReportNameEN', N'Gross Profit Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'ReportNameTH', N'รายงานสรุปกำไรขั้นต้นตามประเภทงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'ACC', N'Accounting Reports / รายงานแผนกบัญชี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'ADV', N'Advancing Reports / รายงานการเบิกเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'CLR', N'Clearing Reports / รายงานการปิดบัญชี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'EXE', N'Executives Reports / รายงานสำหรับผู้บริหาร')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'FIN', N'Financial Reports / รายงานแผนกการเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'INV', N'Invoicing Reports / รายงานใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'JOB', N'Operation Reports / รายงานการปฏิบัติงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'MAS', N'Master Files Reports / รายงานข้อมูลมาตรฐาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'MKT', N'Marketing Reports / รายงานแผนกการตลาด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROUP', N'RCV', N'Receiving Reports / รายงานใบเสร็จ/ใบกำกับภาษี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_CLITERIA', N'AND,ih.DocDate, ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.BillIssueDate,inv.BillAcceptNo,inv.BillAcceptDate,inv.DueDate,inv.SDescription,inv.Amt,
inv.AmtVat,  
inv.AmtCredit,
inv.Amt50Tavi,
inv.TotalInv as TotalNet,inv.CreditNet as ''Adjust Amount'',inv.ReceivedNet as TotalReceived,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.DocDate,inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'ReportGroup', N'INV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'ReportNameEN', N'Invoice Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'ReportNameTH', N'รายงานใบแจ้งหนี้ประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,ih.RefNo, ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode,id.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.SDescription,inv.AmtAdvance,inv.AmtCharge as TotalCharge,inv.AmtCredit,
(CASE WHEN inv.AmtCharge>0 THEN inv.AmtVat ELSE 0 END) as TotalVAT
,(CASE WHEN inv.AmtCharge>0 THEN inv.Amt50Tavi ELSE 0 END) as TotalWHT
,inv.TotalInv as TotalNet,inv.ReceivedNet as TotalReceived,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.SDescription,inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'ReportGroup', N'INV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'ReportNameEN', N'Invoice Expenses Detail')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'ReportNameTH', N'รายงานใบแจ้งหนี้ตามประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_CLITERIA', N'WHERE,ih.DocDate,ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_SQL', N'SELECT 
(CASE WHEN inv.CancelProve<>'''' THEN ''*''+inv.DocNo ELSE inv.DocNo END) as DocNo
,inv.DocDate,inv.CustCode,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtAdvance END) as TotalAdvance,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtCharge END) as TotalCharge,
sum(CASE WHEN inv.CancelProve<>'''' OR inv.AmtCharge=0 THEN 0 ELSE inv.AmtVat END) as TotalVAT,
sum(CASE WHEN inv.CancelProve<>'''' OR inv.AmtCharge=0 THEN 0 ELSE inv.Amt50Tavi END) as Total50Tavi,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtCredit END) as TotalPrepaid,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.TotalInv END) as TotalNet,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE ISNULL(inv.CreditNet,0) END) as TotalCredit,
sum(case when inv.BillAcceptNo='''' AND NOT inv.CancelProve<>'''' THEN inv.TotalInv ELSE 0 END) as UNBILLED,
sum(case when inv.BillAcceptNo<>'''' AND NOT inv.CancelProve<>'''' THEN inv.TotalInv ELSE 0 END) as BILLED,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.ReceivedNet END) as TotalReceived,
max(CASE WHEN inv.CancelProve<>'''' THEN '''' ELSE inv.LastVoucher END) as VoucherNo 
FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id right join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
{0}
) inv 
GROUP BY inv.DocNo,inv.CancelProve,inv.DocDate,inv.RefNo,inv.CustCode
ORDER BY inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'ReportGroup', N'INV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'ReportNameEN', N'Invoice Status')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'ReportNameTH', N'รายงานสถานะใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_CLITERIA', N'AND,f.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_SQL', N'SELECT DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,
ISNULL(AmtCost,0) as TotalCost,
SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END) as TotalCharge,
SUM(AmtCredit) as TotalPrepaid,
SUM(ReceiptNet) as TotalReceived,
SUM(Balance) as TotalBalance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END)-ISNULL(AmtCost,0) as TotalProfit
FROM (
	select f.BranchCode,f.DocNo,f.DocDate as InvDate, f.CustCode,f.CustBranch,c.JNo,c.DocDate as JobDate ,b.ClrNo,b.ClrDate,c.DeclareNumber,c.InvNo,
	c.DutyDate,c.CloseJobDate,c.CSCode,c.ShippingEmp,c.ManagerCode,c.InvProduct,c.VesselName,c.TotalContainer,e.Title+''''+e.NameThai as CustName,
	f.BillAcceptNo,f.BillIssueDate,f.BillAcceptDate,f.DueDate,a.SICode,
	d.NameThai as SDescription,d.IsExpense,d.IsCredit,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	h.AmtAdvance,h.AmtCharge,h.AmtVat,h.Amt50Tavi,h.TotalAmt,h.AmtCredit,(h.TotalAmt+h.AmtCredit) as TotalNet,g.ReceiptNet,
	g.ReceiptNo,g.VoucherNo,i.AdjAmt as AdjustAmt,(a.BNet-h.AmtCredit)-ISNULL(g.ReceiptNet,0) as Balance
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	inner join Job_InvoiceHeader f on a.BranchCode=f.BranchCode and a.LinkBillNo=f.DocNo
	left join (
		SELECT dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,Max(dt.ReceiptNo) as ReceiptNo 
		,sum(dt.Net) as ReceiptNet,Max(dt.VoucherNo) as VoucherNo from
		Job_ReceiptDetail dt INNER JOIN Job_ReceiptHeader hd ON dt.BranchCode=hd.BranchCode
		AND dt.ReceiptNo=hd.ReceiptNo WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.InvoiceNo<>'''' 
		GROUP BY dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo) g 
		ON a.BranchCode=g.BranchCode AND a.LinkBillNo=g.InvoiceNo AND a.LinkItem=g.InvoiceItemNo
	inner join Job_InvoiceDetail h on a.BranchCode=h.BranchCode and a.LinkBillNo=h.DocNo and a.LinkItem=h.ItemNo
	left join (
		SELECT dt.BranchCode,dt.BillingNo as InvoiceNo,dt.BillItemNo as InvoiceItemNo,sum(dt.TotalNet) as AdjAmt FROM Job_CNDNDetail dt inner join Job_CNDNHeader hd on dt.BranchCode=hd.BranchCode
		and dt.DocNo=hd.DocNo WHERE hd.DocStatus<>99 GROUP BY dt.BranchCode,dt.BillingNo,dt.BillItemNo
		) i 
		ON h.BranchCode=i.BranchCode and h.DocNo=i.InvoiceNo and h.ItemNo=i.InvoiceItemNo
	where ISNULL(b.CancelProve,'''')='''' AND ISNULL(f.CancelProve,'''')='''' AND c.JobStatus<>99 {0}
) inv 
left join (
	SELECT dt.BranchCode,dt.LinkBillNo,dt.JobNo,SUM(dt.BNet) as AmtCost FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo WHERE ISNULL(hd.CancelProve,'''')=''''
	AND dt.LinkItem=0 AND hd.ClearType=2 GROUP BY dt.BranchCode,dt.LinkBillNo,dt.JobNo
) cost ON inv.BranchCode=cost.BranchCode AND inv.DocNo=cost.LinkBillNo AND inv.JNo=cost.JobNo
GROUP BY DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,AmtCost
ORDER BY CustCode,InvDate,DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'ReportGroup', N'INV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'ReportNameEN', N'Invoice Costing Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'ReportNameTH', N'รายงานสรุปต้นทุนตามใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_CLITERIA', N'AND,c.PaymentDate,c.CustCode,a.ForJNo,c.ReqBy,a.VenCode,c.DocStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_SQL', N'SELECT t.PaymentDate,t.AdvNo,t.JobNo,t.ReqBy,t.SDescription,t.PaymentRef,t.DocStatus,t.AdvNet,t.UsedAmount,t.AdvBalance FROM (
Select a.BranchCode,'''' as ClrNo,0 as ItemNo,0 as LinkItem,
a.STCode,a.SICode,a.SDescription,a.VenCode as VenderCode,
a.AdvQty as Qty,b.UnitCharge as UnitCode,a.CurrencyCode,a.ExchangeRate as CurRate,
(CASE WHEN b.IsExpense=0 THEN a.UnitPrice ELSE 0 END) as UnitPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice ELSE 0 END) as FPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice*a.ExchangeRate ELSE 0 END) as BPrice,
q.TotalCharge as QUnitPrice,a.AdvQty*q.ChargeAmt as QFPrice,a.AdvQty*q.ChargeAmt*q.CurrencyRate as QBPrice,
a.UnitPrice as UnitCost,a.AdvQty*a.UnitPrice as FCost,a.AdvQty*a.UnitPrice*a.ExchangeRate as BCost,
a.ChargeVAT,a.Charge50Tavi as Tax50Tavi,a.AdvNo as AdvNO,d.AdvDate,a.ItemNo as AdvItemNo,a.AdvAmount,a.AdvNet,
a.AdvNet-ISNULL(d.TotalCleared,0) as AdvBalance,ISNULL(d.TotalCleared,0) as UsedAmount,
(CASE WHEN ISNULL(q.QNo,'''')='''' THEN 0 ELSE 1 END) as IsQuoItem,
a.IsDuplicate,b.IsExpense,
b.IsLtdAdv50Tavi,(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN '''' ELSE a.PayChqTo END) as Pay50TaviTo,a.Doc50Tavi as NO50Tavi,NULL as Date50Tavi,
(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN a.PayChqTo ELSE '''' END) as VenderBillingNo,'''' as SlipNO,'''' as Remark,
(SELECT STUFF((
	SELECT DISTINCT '','' + Convert(varchar,QtyBegin) + ''-''+convert(varchar,QtyEnd)+''=''+convert(varchar,ChargeAmt)
	FROM Job_QuotationItem WHERE BranchCode=q.BranchCode
	AND QNo=q.QNo AND SICode=q.SICode AND VenderCode =q.VenderCode
	AND UnitCheck=q.UnitCheck AND CalculateType=1
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AirQtyStep,q.CalculateType as StepSub,
a.ForJNo as JobNo,a.IsChargeVAT as VATType,a.VATRate,a.Rate50Tavi as Tax50TaviRate,q.QNo,
c.DocStatus,c.AdvBy,c.EmpCode as ReqBy,c.PaymentDate,c.CustCode,c.PaymentRef
FROM Job_AdvDetail a LEFT JOIN Job_SrvSingle b on a.SICode=b.SICode
INNER JOIN Job_AdvHeader c on a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo 
left join Job_Order j on a.BranchCode=j.BranchCode and a.ForJNo=j.JNo
left join 
(
	select qh.BranchCode,qh.QNo,
	qd.JobType,qd.ShipBy,qd.SeqNo,
	qi.ItemNo,qi.SICode,qi.CalculateType,
	qi.QtyBegin,qi.QtyEnd,qi.UnitCheck,qi.CurrencyCode,
	qi.CurrencyRate,qi.ChargeAmt,qi.Isvat,qi.VatRate,
	qi.VatAmt,qi.IsTax,qi.TaxRate,qi.TaxAmt,
	qi.TotalAmt,qi.TotalCharge,qi.UnitDiscntPerc,qi.UnitDiscntAmt,
	qi.VenderCode,qi.VenderCost,qi.BaseProfit,qi.CommissionPerc,qi.CommissionAmt,
	qi.NetProfit,qi.IsRequired
	from Job_QuotationHeader qh	inner join Job_QuotationDetail qd ON qh.BranchCode=qd.BranchCode and qh.QNo=qd.QNo
	inner join Job_QuotationItem qi	on qd.BranchCode=qi.BranchCode and qd.QNo=qi.QNo and qd.SeqNo=qi.SeqNo 
    where qh.DocStatus=3 
) q
on a.BranchCode=q.BranchCode and b.SICode=q.SICode and ISNULL(a.VenCode,b.DefaultVender)=q.VenderCode 
and b.UnitCharge=q.UnitCheck and a.AdvQty <=q.QtyEnd and a.AdvQty>=q.QtyBegin and q.QNo=j.QNo
left join 
(
	SELECT ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,
    SUM(ISNULL(cd.BNet,0)) as TotalCleared    
	FROM Job_ClearDetail cd INNER JOIN Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode	and cd.ClrNo =ch.ClrNo 	and ch.DocStatus<>99
    INNER JOIN Job_AdvDetail ad on cd.BranchCode=ad.BranchCode and cd.AdvNO=ad.AdvNo and cd.AdvItemNo=ad.ItemNo
    INNER JOIN Job_AdvHeader ah on ad.BranchCode=ah.BranchCode and ad.AdvNo=ah.AdvNo
    WHERE ah.DocStatus<>99 AND ch.DocStatus<>99 
	GROUP BY ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,ad.IsDuplicate,ad.AdvNet
) d
ON a.BranchCode=d.BranchCode and a.AdvNo=d.AdvNo and a.ItemNo=d.ItemNo
WHERE c.DocStatus<90 {0} ) t ORDER BY t.ReqBy,t.PaymentDate,t.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'ReportGroup', N'ADV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'ReportNameEN', N'Advance By Emp')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'ReportNameTH', N'รายงานการเบิกเงินตามพนักงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_CLITERIA', N'AND,jd.ConfirmDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_SQL', N'SELECT CustCode,CSCode,AgentCode,JNo, DeclareNumber,DocDate, CreateDate, ConfirmDate,
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate,
DATEDIFF(d,CreateDate,DutyDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,DutyDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,DutyDate,CloseJobDate) as CloseDays,
 LastInvDate,
 DATEDIFF(d,LastClearDate,LastInvDate) as InvDays,
 LastRcvDate,
 DATEDIFF(d,LastInvDate,LastRcvDate) as RcvDays
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0} ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'ReportNameEN', N'Job Analysis')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'ReportNameTH', N'รายงานประเมินผลการปฏิบัติงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_CLITERIA', N'AND,h.ReceiptDate,j.CustCode,j.JNo,j.ManagerCode,j.ForwarderCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_SQL', N'select q.DocStatus,j.ManagerCode,j.CustCode,j.CustBranch,j.QNo,q.DocDate as QuoDate,
j.JNo,j.InvNo,d.ReceiptNo,h.ReceiptDate,j.TotalContainer,
MAX(d.VoucherNo) as VoucherNo,SUM(d.Net) as TotalCharge,
dbo.GetCommission(SUM(d.Net),j.ManagerCode) as Commission
from Job_ReceiptDetail d inner join Job_ReceiptHeader h
on d.BranchCode=h.BranchCode 
and d.ReceiptNo=h.ReceiptNo
inner join Job_ClearDetail c
on d.BranchCode=c.BranchCode 
and d.InvoiceNo=c.LinkBillNo
and d.InvoiceItemNo=c.LinkItem
inner join Job_SrvSingle s
on d.SICode=s.SICode
inner join Job_Order j
on c.BranchCode=j.BranchCode
and c.JobNo=j.JNo
left join Job_QuotationHeader q
on j.BranchCode =q.BranchCode
and j.QNo=q.QNo
where NOT ISNULL(h.CancelProve,'''')<>''''
and s.IsExpense=0 and s.IsCredit=0 {0}
group by j.ManagerCode,j.CustCode,j.CustBranch,j.QNo,q.DocDate,q.DocStatus,j.JNo,
j.InvNo,j.TotalContainer,d.ReceiptNo,h.ReceiptDate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'ReportAuthor', N'1,2,3,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'ReportGroup', N'MKT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'ReportNameEN', N'Job Commission By Emp')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'ReportNameTH', N'รายงานสรุปค่าคอมมิชชั่น')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.ForwarderCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_SQL', N'SELECT j.DocDate,j.DutyDate as InspectionDate,j.JNo,jt.JobTypeName,sb.ShipByName
,c.NameEng as Customer,e.NameEng as Consignee,j.DeliveryTo as Shipper,v.TName as Agent,
j.InvProduct,j.InvNo,j.HAWB,j.DeclareNumber,j.ETDDate,j.ETADate,j.LoadDate,j.EstDeliverDate as UnloadDate,j.TotalContainer,
cl.SumCost,cl.SumAdvance,cl.SumCharge,cl.Profit,
j.CSCode,j.ShippingEmp,ad.TotalAdvance,ad.TotalExpClear,ad.TotalPayback,ad.TotalReturn,
cl.TotalEarnest,cl.DepositReturnDate,
j.CloseJobDate
FROM dbo.Job_Order AS j 
 LEFT JOIN (
 SELECT h.BranchCode,d.ForJNo,
 SUM(d.AdvNet) as TotalAdvance,
 SUM(ISNULL(c.BNet,0)) AS TotalExpClear,
 SUM(CASE WHEN c.BNet >d.AdvNet AND c.BNet>0 THEN c.BNet-d.AdvNet ELSE 0 END) as TotalPayback,
 SUM(CASE WHEN c.BNet <d.AdvNet AND c.BNet>0 THEN d.AdvNet-c.BNet ELSE 0 END) as TotalReturn
 FROM Job_AdvDetail d INNER JOIN Job_AdvHeader h
 ON h.BranchCode=d.BranchCode AND h.AdvNo=d.AdvNo
 left join (
	SELECT a.BranchCode,b.AdvNO,b.AdvItemNo,SUM(b.BNet) as BNet
	FROM Job_ClearDetail b INNER JOIN Job_ClearHeader a
	ON b.BranchCode=a.BranchCode AND b.ClrNo=a.ClrNo
	WHERE a.DocStatus<>99
	GROUP BY a.BranchCode,b.AdvNO,b.AdvItemNo
 ) c ON d.BranchCode=c.BranchCode AND d.AdvNo=c.AdvNO AND d.ItemNo=c.AdvItemNo
 WHERE h.DocStatus<>99
 GROUP BY h.BranchCode,d.ForJNo
 ) ad ON j.BranchCode=ad.BranchCode AND j.JNo=ad.ForJNo
 LEFT JOIN ( 
 SELECT ch.BranchCode,cd.JobNo,
 SUM(CASE WHEN sv.IsExpense=1 AND cd.LinkItem=0 THEN cd.BNet ELSE 0 END) AS SumCost,
 SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
 SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumCharge,
 SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 AND cd.LinkItem=0 THEN cd.BNet ELSE 0 END) as Profit,
 SUM(CASE WHEN CHARINDEX(''ERN'',cd.SICode)>0 OR CHARINDEX(''B-DEP'',cd.SICode)>0 THEN cd.BNet ELSE 0 END) AS TotalEarnest,
 (SELECT TOP 1 VoucherDate FROM Job_CashControl WHERE BranchCode=ch.BranchCode AND ControlNo= MAX(CASE WHEN CHARINDEX(''ERN'',cd.SICode)>0 And cd.LinkBillNo<>'''' THEN cd.LinkBillNo ELSE '''' END) ) AS DepositReturnDate
 FROM dbo.Job_ClearDetail AS cd 
 LEFT JOIN  dbo.Job_ClearHeader AS ch 
 ON cd.BranchCode = ch.BranchCode 
 AND cd.ClrNo=ch.ClrNo 
 LEFT JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 WHERE  (isnull(ch.DocStatus,0)<>99) 
 GROUP BY ch.BranchCode,cd.JobNo
 ) cl
 on j.BranchCode=cl.BranchCode AND j.JNo=cl.JobNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON j.ShipBy=sb.ShipBy
INNER JOIN dbo.Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN (SELECT CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng FROM dbo.Mas_Company GROUP BY CustCode) e ON j.CustCode=e.CustCode AND j.CustBranch=e.Branch
LEFT JOIN Mas_Vender v ON j.ForwarderCode=v.VenCode WHERE j.JobStatus<>99 {0}
ORDER BY j.DocDate,j.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'ReportNameEN', N'Job Costing Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'ReportNameTH', N'รายงานสรุปต้นทุนตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_SQL', N'SELECT j.JNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CSCode,j.InvNo,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0} ) j  ORDER BY j.CSCode DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'ReportNameEN', N'Job List By CS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'ReportNameTH', N'รายงานการตรวจปล่อยตามพนักงานบริการลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type] {0}
) j  ORDER BY j.CustCode,j.DutyDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'ReportNameEN', N'Job List By Customer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'ReportNameTH', N'รายงานการตรวจปล่อยตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,j.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.DeclareNumber,j.VesselName,j.LoadDate,j.DutyDate,j.ShippingEmp,j.HAWB,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName,c.CommLevel
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.LoadDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'ReportNameEN', N'Job List Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'ReportNameTH', N'รายงานการตรวจปล่อยตามวันที่')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDETAIL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDETAIL', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDETAIL', N'ReportNameEN', N'Details of PNL By Job Order')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDETAIL', N'ReportNameTH', N'รายงานรายละเอียดกำไรขั้นต้นตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDETAIL', N'ReportType', N'FIX')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_SQL', N'SELECT j.JNo,j.DeclareNumber,j.HAWB,j.ConfirmDate,j.ImExDate,j.CloseJobDate,j.JobStatus,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.Consigneecode,j.InvProduct,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.JobStatus,j.JNo DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'ReportNameEN', N'Job List By Status')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'ReportNameTH', N'รายงานงานเรียงตามสถานะ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'MAIN_CLITERIA', N'AND,jd.CreateDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'MAIN_SQL', N'SELECT NameEng as Customer,CSCode,TName as Agent,JNo, DeclareNumber,CreateDate, ConfirmDate,
DATEDIFF(d,CreateDate,ConfirmDate) as OpenDays,
LoadDate,DutyDate as InspectionDate,EstDeliverDate as UnloadDate,
DATEDIFF(d,LoadDate,EstDeliverDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,EstDeliverDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,CloseJobDate,LastClearDate) as CloseDays, 
 DATEDIFF(d,ConfirmDate,CloseJobDate) as TotalDays
FROM            dbo.Job_Order AS jd 
INNER JOIN Mas_Company c ON jd.CustCode=c.CustCode AND jd.CustBranch=c.Branch
LEFT JOIN Mas_Vender v ON jd.AgentCode=v.VenCode
LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0}
 ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'ReportNameEN', N'Job Operation On-Time Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'ReportNameTH', N'รายงานสรุปเวลาปฏิบัติงานตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_CLITERIA', N'AND,j.ETADate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_SQL', N'SELECT j.JNo as ''Job Number'',j.consigneecode as ''Consignee'',j.BookingNo as ''Booking/BL'',j.TotalContainer as ''CONTAINER'',j.VesselName as ''Vessel/Flight'',j.ForwarderCode as ''Agent'',
t.TransMode as ''MODE'',t.CYPlace + ''-'' +t.PackingPlace as ''Transport Route'',j.ETADate as ''ETA Date'',j.ReadyToClearDate as ''Ready Date'',j.ShippingEmp as ''Shipping'',j.DutyDate as ''Inspection Date''
,j.DeclareStatus,j.EstDeliverDate as ''Delivery Date'',t.ReturnDate as ''Demurrage Date'',t.FactoryPlace as ''Delivery Place''
FROM Job_Order j LEFT JOIN Job_Loadinfo t
ON j.BranchCode=t.BranchCode and j.JNo=t.JNo
WHERE j.JobStatus<>99  {0}
ORDER BY j.ETADate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'ReportNameEN', N'Job Loading By ETA Date')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'ReportNameTH', N'รายงานงานขนส่งตามวันเทียบท่า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_CLITERIA', N'AND,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_SQL', N'SELECT j.JNo,j.InvProduct,j.LoadDate,j.CustCode,j.DeclareNumber,j.HAWB,j.InvNo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.ShippingEmp FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'ReportNameEN', N'Job List By Port')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'ReportNameTH', N'รายงานการตรวจปล่อยตามสถานที่ตรวจปล่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_SQL', N'SELECT j.CSCode,j.ManagerCode, j.JNo, j.DocDate as JobDate, 
jt.JobTypeName as JobType,sb.ShipByName as ShipBy,c.NameEng as CustEName,
j.HAWB, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo as CustInvNo,j.TotalContainer,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.GroupCode IN(''ERN'',''B-DEP'') THEN cd.UsedAmount ELSE 0 END) AS TotalEarnest,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit,
CASE WHEN SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)>0 THEN
CAST(100*((SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END))/SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) ) as numeric(10,2)) 
ELSE 0 END
as Margin
FROM dbo.Job_ClearHeader AS ch INNER JOIN
dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
 AND ch.ClrNo=cd.ClrNo
 INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 INNER JOIN
 dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON j.ShipBy=sb.ShipBy
inner join Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE (cd.BNet>0) AND (ISNULL(ch.CancelProve,'''')='''') AND (j.JobStatus < 90) {0}
GROUP BY j.CSCode,j.ManagerCode, j.JNo, j.DocDate ,
jt.JobTypeName,sb.ShipByName,c.NameEng,
j.HAWB, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo,j.TotalContainer
ORDER BY j.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'ReportNameEN', N'Job Costing And Profit')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'ReportNameTH', N'รายงานกำไรขั้นต้นตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.ManagerCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.ManagerCode) j INNER JOIN Mas_User c ON j.ManagerCode=c.UserID ORDER BY c.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'ReportAuthor', N'1,2,3,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'ReportGroup', N'MKT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'ReportNameEN', N'Job Sales By Emp')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'ReportNameTH', N'รายงานสรุปยอดขายตามพนักงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'ReportNameEN', N'Job List By Transport')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'ReportNameTH', N'รายงานการตรวจปล่อยตามลักษณะงานขนส่ง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.VesselName,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.ShippingCmd FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShippingEmp DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'ReportNameEN', N'Job List By Shipping')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'ReportNameTH', N'รายงานการตรวจปล่อยตามชิปปิ้ง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode, j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.CSCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.CSCode) j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'ReportAuthor', N'1,2,3,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'ReportGroup', N'MKT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'ReportNameEN', N'Job Volume By Status')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'ReportNameTH', N'รายงานสรุปงานตามสถานะ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_CLITERIA', N'AND,c.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode,,e.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_SQL', N'SELECT JNo,DeclareNumber,InvNo,DutyDate,LoadDate,CloseJobDate,CustCode,
SUM(AdvCleared) as TotalAdv,
SUM(ChargeCleared) as TotalCharge,
SUM(AdvBilled) as TotalAdvBilled,
SUM(ChargeBilled) as TotalChargeBilled,
SUM(CostCleared) as TotalCost,
SUM(DepositAmt) as TotalEarnest,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChargeWaitBill) as TotalChargeWaitBill
FROM (
	select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,c.LoadDate,
	b.ClrNo,b.ClrDate,b.ClearType,b.DocStatus,a.AdvNo,a.AdvItemNo,c.CustCode,c.CustBranch,
	e.Title+'' ''+e.NameThai as CustName,a.SICode,a.SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
	a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
	(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
    (CASE WHEN d.GroupCode IN(''ERN'',''B-DEP'') THEN a.UsedAmount ELSE 0 END) as DepositAmt,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as ChargeWaitBill,
	(CASE WHEN d.IsExpense=1 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
	(CASE WHEN d.IsExpense=1 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 AND NOT ISNULL(a.LinkBillNo,'''')=''''THEN a.UsedAmount ELSE 0 END) as ChargeBilled
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<>99 {0}
) clr
GROUP BY JNo,DeclareNumber,InvNo,DutyDate,LoadDate,CloseJobDate,CustCode
ORDER BY JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'ReportNameEN', N'PNL By Job Order')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'ReportNameTH', N'รายงานสรุปกำไรขาดทุนตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_CLITERIA', N'AND,c.LoadDate,c.NotifyCode,a.JNo,,c.VenderCode,,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_SQL', N'SELECT t.LoadDate,t.NotifyCode,t.VenderCode,t.JNo,t.BookingNo,t.CTN_NO,t.CTN_SIZE,t.TruckNO,t.TruckType,t.Location,
(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as JobStatus,
t.CountBill,t.CountClear
FROM (
SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.LoadDate,c.NotifyCode,c.VenderCode
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'''')<>'''' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'''')='''' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
 INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo
WHERE c.LoadDate IS NOT NULL  {0} ) t ORDER BY t.VenderCode,t.LoadDate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'ReportNameEN', N'Job Transport Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'ReportNameTH', N'รายงานงานขนส่งรายตู้ตามบริษัทขนส่ง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.VesselName,j.DeliveryNo FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'ReportNameEN', N'Job List By Type')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'ReportNameTH', N'รายงานการตรวจปล่อยตามประเภทงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT01', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT01', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT01', N'ReportNameEN', N'Outstanding Job Order By Customer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT01', N'ReportNameTH', N'รายงานสรุปงานคงค้างตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT01', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT02', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT02', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT02', N'ReportNameEN', N'Outstanding Job Order By Customer Service')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT02', N'ReportNameTH', N'รายงานสรุปงานคงค้างตามพนักงานบริการลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT02', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_CLITERIA', N'WHERE,jd.CreateDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode,,cu.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_SQL', N'SELECT jd.CustCode as ''Customer'',CSCode as ''CS'',AgentCode as Vender,JNo as ''Job Number'', DeclareNumber as ''Customs Declare#'',
DocDate as ''Job Date'', CreateDate as ''Creation Date'', 
DATEDIFF(d,CreateDate,DocDate) as ''Open Days'',
DutyDate as ''Customs Inspection Date'',
DATEDIFF(d,CreateDate,DutyDate) as ''Customs Lead Time'',
 LastClearDate as ''Job Clear Date'',
 DATEDIFF(d,DutyDate,LastClearDate) as ''Clear Lead Time'',
  CloseJobDate as ''Job Close Date'',
 DATEDIFF(d,DutyDate,CloseJobDate) as ''Close Lead Time'',
 LastInvDate as ''Invoice Creation Date'',
 DATEDIFF(d,LastClearDate,LastInvDate) as ''Invoice Lead Time'',
 LastRcvDate as ''Receipt Date'',
 DATEDIFF(d,LastInvDate,LastRcvDate) as ''A/R Aging Days'',jd.JobStatus
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
LEFT JOIN Mas_Company cu ON jd.CustCode=cu.CustCode AND jd.CustBranch=cu.Branch
{0}  ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'ReportNameEN', N'Job Order Status')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'ReportNameTH', N'รายงานประเมินผลสถานะการปฏิบัติงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,cu.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_SQL', N'select j.CustCode as ''Customer'',j.JNo as ''Job Number'',j.DeclareNumber as ''Customs Declare#'',j.InvNo as ''Commercial Invoice#''
,j.CSCode as ''CS'',j.CreateDate as ''Job Creation Date'',j.CloseJobDate as ''Job Close Date'',j.JobStatus as ''JobStatus'',
ISNULL(a.TotalAdvPay,0) as ''Invoice To Customer-Advance'',
ISNULL(c.TotalService,0) as ''Invoice To Customer-Service'',
ISNULL(c.TotalAdvClear,0) as ''Payment To Vender-Advance'',
ISNULL(c.TotalCost,0) as ''Payment To Vender-Cost'',
ISNULL(c.TotalDeposit,0) as ''Payment To Vender-Deposit'',
ISNULL(c.TotalService,0)-ISNULL(c.TotalCost,0) as ''Profit'',
ISNULL(c.TotalAdvBill,0) as ''Customer Billed-Advance'',
ISNULL(c.TotalServiceBill,0) as ''Customer Billed-Service'',
ISNULL(c.TotalAdvUnBill,0) as ''Customer Unbilled-Advance'',
ISNULL(c.TotalServiceUnBill,0) as ''Customer Unbilled-Service'',
ISNULL(p.TotalVenderBill,0) as ''Exp-Billed'',
ISNULL(p.TotalVenderUnBill,0) as ''Exp-Unbilled'',
ISNULL(p.TotalVenderPaid,0) as ''Exp-Paid''
from Job_Order j
left join Mas_Company cu ON j.CustCode=cu.CustCode AND j.CustBranch=cu.Branch
left join (
	select h.BranchCode,d.ForJNo,sum(d.AdvNet) as TotalAdvPay
	from Job_AdvHeader h inner join Job_AdvDetail d
	on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
	where h.DocStatus<99
	group by h.BranchCode,d.ForJNo
) a on j.BranchCode=a.BranchCode and j.JNo=a.ForJNo
left join (
	select h.BranchCode,d.JobNo,sum(CASE WHEN h.ClearType=1 THEN d.BNet ELSE 0 END) as TotalAdvClear,
	sum(CASE WHEN SUBSTRING(d.SICode,1,4) NOT IN(''ERN-'',''B-DE'') AND h.ClearType=2 THEN d.BNet ELSE 0 END) as TotalCost,
	sum(CASE WHEN SUBSTRING(d.SICode,1,4) IN(''ERN-'',''B-DE'') THEN d.BNet ELSE 0 END) as TotalDeposit,
	sum(CASE WHEN h.ClearType=3 THEN d.BNet ELSE 0 END) as TotalService,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalAdvBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalServiceBill,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalAdvUnBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalServiceUnBill
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
	where h.DocStatus<99
	group by h.BranchCode,d.JobNo	
) c ON j.BranchCode=c.BranchCode AND j.JNo=c.JobNo
left join (
	select h.BranchCode,d.ForJNo,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderPaid,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')='''' AND ISNULL(h.ApproveRef,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderBill,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')='''' AND ISNULL(h.ApproveRef,'''')=''''THEN d.Total ELSE 0 END) as TotalVenderUnBill
	from Job_PaymentHeader h inner join Job_PaymentDetail d
	on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
	inner join Job_SrvSingle s ON d.SICode=s.SICode
	where NOT ISNULL(h.CancelProve,'''')<>''''
	group by h.BranchCode,d.ForJNo
) p ON j.BranchCode=p.BranchCode AND j.JNo=p.ForJNo
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'ReportNameEN', N'Outstanding Job By Customer/Waiting for Billing')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'ReportNameTH', N'รายงานติดตามผลการดำเนินงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_CLITERIA', N'AND,h.AdvDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,cu.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_SQL', N'select d.ForJNo as ''Job Number'',h.AdvNo+''/''+CAST(d.ItemNo as varchar) as ''Advance No'',ISNULL(c.LastClrNo,'''') as ''Clearing No'',
c.LastClrDate as ''Clearing Date'',ISNULL(c.LastInvNo,'''') as ''Invoice No'',c.LastInvDate as ''Invoice Date'',
(CASE WHEN ISNULL(c.LastInvNo,'''')='''' THEN DATEDIFF(DAY,c.LastClrDate,GetDate()) ELSE 0 END) as ''Unbilled Aging Day'',
(CASE WHEN ISNULL(c.LastInvNo,'''')<>'''' THEN DATEDIFF(DAY,c.LastClrDate,c.LastInvDate) ELSE 0 END) as ''Billed Aging Day'',
h.CustCode as ''Customer'',ISNULL(c.LastReceiptNo,'''') as ''Receipt No'',c.LastReceiptDate as ''Receipt Date'',
(d.AdvNet) as ''Advance Amount'',
(CASE WHEN c.ClrNet IS NULL THEN d.AdvNet ELSE 0 END) as ''Advance Unclear'',
ISNULL(c.ClrNet,0) as ''Actual Spending'',
ISNULL(c.ClrBillAble,0) as ''Billable Amount'',
ISNULL(c.ClrVat,0) as ''TotalVAT'',
ISNULL(c.ClrWht,0) as ''TotalWHT'',
ISNULL(c.ClrBilled,0) as ''Billed Advance'',
ISNULL(c.ClrUnBilled,0) as ''Unbilled Advance''
from Job_AdvHeader h inner join Job_AdvDetail d
on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
left join Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
left join Mas_Company cu ON h.CustCode=cu.CustCode AND h.CustBranch=cu.Branch 
left join (
	select a.BranchCode,b.AdvNo,b.AdvItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo+''/''+CAST(b.ItemNo as varchar)) as LastClrNo,
    sum(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN ISNULL(b.LinkBillNo,'''')='''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.LinkBillNo+''/''+cast(b.LinkItem as varchar) ELSE '''' END) as LastInvNo,
	Max(i.DocDate) as LastInvDate,MAX(r.ReceiptNo+''/''+CAST(r.ItemNo as varchar)) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 and isnull(b.AdvNo,'''')<>'''' AND ISNULL(t.CancelProve,'''')=''''
	group by a.BranchCode,b.AdvNo,b.AdvItemNo
) c
on d.BranchCode=c.BranchCode and d.AdvNo=c.AdvNo and d.ItemNo=c.AdvItemNo
where  h.DocStatus<99 and j.JobStatus<>99 {0}
union
select d.ForJNo as ''Job Number'',h.DocNo+''/''+CAST(d.ItemNo as varchar) as ''Advance No'',ISNULL(c.LastClrNo,'''') as ''Clearing No'',
c.LastClrDate as ''Clearing Date'',ISNULL(c.LastInvNo,'''') as ''Invoice No'',c.LastInvDate as ''Invoice Date'',
(CASE WHEN ISNULL(c.LastInvNo,'''')='''' THEN DATEDIFF(DAY,c.LastClrDate,GetDate()) ELSE 0 END) as ''Unbilled Aging Day'',
(CASE WHEN ISNULL(c.LastInvNo,'''')<>'''' THEN DATEDIFF(DAY,c.LastClrDate,c.LastInvDate) ELSE 0 END) as ''Billed Aging Day'',
j.CustCode as ''Customer'',ISNULL(c.LastReceiptNo,'''') as ''Receipt No'',c.LastReceiptDate as ''Receipt Date'',
(d.Total) as ''Advance Amount'',
(CASE WHEN c.ClrNet IS NULL THEN d.Total ELSE 0 END) as ''Advance Unclear'',
ISNULL(c.ClrNet,0) as ''Actual Spending'',
ISNULL(c.ClrBillAble,0) as ''Billable Amount'',
ISNULL(c.ClrVat,0) as ''TotalVAT'',
ISNULL(c.ClrWht,0) as ''TotalWHT'',
ISNULL(c.ClrBilled,0) as ''Billed Advance'',
ISNULL(c.ClrUnBilled,0) as ''Unbilled Advance''
from (select *,DocDate as AdvDate from Job_PaymentHeader) as h inner join Job_PaymentDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
left join Job_Order j ON d.BranchCode=j.BranchCode AND d.forJNo=j.JNo
left join Mas_Company cu ON j.CustCode=cu.CustCode AND j.CustBranch=cu.Branch 
left join (
select a.BranchCode,p.DocNo as VenderInvNo,
	p.ItemNo as VenderItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo+''/''+CAST(b.ItemNo as varchar)) as LastClrNo,
    sum(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN ISNULL(b.LinkBillNo,'''')='''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.LinkBillNo+''/''+CAST(b.LinkItem as varchar) ELSE '''' END) as LastInvNo,
	Max(i.DocDate) as LastInvDate,
	MAX(r.ReceiptNo+''/''+CAST(r.ItemNo as varchar)) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_PaymentDetail p ON b.ClrNo=p.ClrRefNo AND b.ItemNo=p.ClrItemNo
	inner join Job_PaymentHeader h ON p.BranchCode=h.BranchCode AND p.DocNo=h.DocNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 AND ISNULL(t.CancelProve,'''')=''''
	AND NOT ISNULL(h.CancelProve,'''')<>'''' AND NOT ISNULL(i.CancelProve,'''')<>''''
	group by a.BranchCode,p.DocNo,p.ItemNo
) c
on d.BranchCode=c.BranchCode and d.DocNo=c.VenderInvNo and d.ItemNo=c.VenderItemNo
where NOT ISNULL(h.CancelProve,'''')<>'''' and j.JobStatus<>99 {0}
union
select d.JobNo as ''Job Number'',h.ClrNo+''/''+CAST(d.ItemNo as varchar) as ''Advance No'',h.ClrNo as ''Clearing No'',
h.ClrDate as ''Clearing Date'',ISNULL(c.LastInvNo,'''') as ''Invoice No'',c.LastInvDate as ''Invoice Date'',
(CASE WHEN ISNULL(c.LastInvNo,'''')='''' THEN DATEDIFF(DAY,h.ClrDate,GetDate()) ELSE 0 END) as ''Unbilled Aging Day'',
(CASE WHEN ISNULL(c.LastInvNo,'''')<>'''' THEN DATEDIFF(DAY,h.ClrDate,c.LastInvDate) ELSE 0 END) as ''Billed Aging Day'',
j.CustCode as ''Customer'',ISNULL(c.LastReceiptNo,'''') as ''Receipt No'',c.LastReceiptDate as ''Receipt Date'',
(d.BNet) as ''Advance Amount'',
0 as ''Advance Unclear'',
d.BNet as ''Actual Spending'',
ISNULL(c.ClrBillAble,0) as ''Billable Amount'',
ISNULL(c.ClrVat,0) as ''TotalVAT'',
ISNULL(c.ClrWht,0) as ''TotalWHT'',
ISNULL(c.ClrBilled,0) as ''Billed Advance'',
ISNULL(c.ClrUnBilled,0) as ''Unbilled Advance''
from (select *,ClrDate as AdvDate from Job_ClearHeader) as h inner join Job_ClearDetail d
on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Job_Order j ON d.BranchCode=j.BranchCode AND d.JobNo=j.JNo
left join Mas_Company cu ON j.CustCode=cu.CustCode AND j.CustBranch=cu.Branch 
left join (
	select a.BranchCode,b.ClrNo,b.ItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo+''/''+CAST(b.ItemNo as varchar)) as LastClrNo,
    sum(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN ISNULL(b.LinkBillNo,'''')='''' THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN b.LinkBillNo+''/''+cast(b.LinkItem as varchar) ELSE '''' END) as LastInvNo,
	Max(i.DocDate) as LastInvDate,MAX(r.ReceiptNo+''/''+CAST(r.ItemNo as varchar)) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 AND ISNULL(t.CancelProve,'''')=''''
	group by a.BranchCode,b.ClrNo,b.ItemNo
) c
on d.BranchCode=c.BranchCode and d.ClrNo=c.ClrNo and d.ItemNo=c.ItemNo
where NOT ISNULL(h.CancelProve,'''')<>'''' AND ISNULL(d.AdvNo,'''')='''' AND ISNULL(d.VenderBillingNo,'''')='''' 
and j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'ReportNameEN', N'Outstanding Advance By Job')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'ReportNameTH', N'รายงานติดตามการเบิกค่าใช้จ่ายตามจ๊อบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_CLITERIA', N'AND,a.AdvDate,,,a.EmpCode,,,a.BranchCode,,b.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_SQL', N'select b.NameEng as ''Customer Name'',b.CreditLimit as ''Advanced Credit Term'',b.DutyLimit as ''Advanced Credit Limit'',
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END) as ''Advance Requested'',
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END) as ''Advance Paid'',
SUM(ISNULL(c.AdvUsed,0)) as ''Paid+Cleared Advance'',
SUM(ISNULL(c.AdvUnbill,0)) as ''Unbilled Advance'',
SUM(ISNULL(c.AdvBilled,0))-SUM(ISNULL(c.AdvReceive,0)) as ''Billed To Customer'',
SUM(ISNULL(c.AdvCost,0)) as ''Advance Cost'',
SUM(ISNULL(c.AdvReceive,0)) as ''Customer Payment'',
(CASE WHEN b.DutyLimit>0 THEN b.DutyLimit
-SUM(ISNULL(c.AdvBilled,0))-SUM(ISNULL(c.AdvReceive,0)) ELSE 0 END)
  as ''Net Avaiable Balance''
from Job_AdvHeader a LEFT JOIN Mas_Company b
ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
left join (
	select h.BranchCode,d.AdvNo,SUM(d.BNet) as AdvUsed,
	SUM(CASE WHEN d.LinkItem>0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvBilled,
	SUM(CASE WHEN d.LinkItem=0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvUnbill,
	SUM(CASE WHEN h.ClearType=''2'' THEN d.BNet ELSE 0 END) as AdvCost,
	SUM(CASE WHEN h.ClearType=''2'' THEN 0 ELSE ISNULL(r.Net,0) END) as AdvReceive
	from Job_ClearHeader h
	inner join Job_ClearDetail d ON h.BranchCode=d.BranchCode
	and h.ClrNo=d.ClrNo
	left join Job_ReceiptDetail r on d.BranchCode=r.BranchCode 
	and d.LinkBillNo=r.InvoiceNo AND d.LinkItem=r.InvoiceItemNo
	left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
	and r.ReceiptNo=t.ReceiptNo
	where h.DocStatus<>99 AND ISNULL(t.CancelProve,'''')=''''
	group by h.BranchCode,d.AdvNo
) c
ON a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo
WHERE a.DocStatus<>99 {0}
group by b.NameEng,b.CreditLimit,b.DutyLimit')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'ReportNameEN', N'Advance By Activity Summary By Customer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'ReportNameTH', N'รายงานติดตามการเบิกค่าใช้จ่ายตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode,e.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_SQL', N'select c.JNo as ''Job Number'',a.AdvNo as ''Advance No'',b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing Date'',c.CustCode as ''Customer'',
b.CTN_NO as ''Container Number'',a.VenderCode as ''Vender'',
a.SlipNO as ''Receipt#'',a.Date50Tavi as ''Receipt Date'',a.UsedAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
a.LinkBillNo as ''V/Receipt#, APLL Inv#'',v.VoucherDate as ''Deposit Received Date''
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode IN(''ERN'',''B-DEP'') AND a.UsedAmount>0 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'ReportNameEN', N'Outstanding Advance By Activity Based-Deposit')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'ReportNameTH', N'รายงานติดตามเงินมัดจำ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,cd.JobNo,ih.EmpCode,cd.VenderCode,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode,,cu.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_SQL', N'select DISTINCT ih.CustCode as ''Customer'',id.DocNo as ''Invoice No'',cd.JobNo as ''Job Number'',ih.DocDate as ''Invoice Date'', cd.SDescription as ''Description'',
(CASE WHEN ch.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN ch.ClearType=3 THEN ''SERV'' ELSE ''COST'' END) END) as ''Type'',
id.Amt as ''Amount'',id.AmtVat as ''TotalVAT'',id.AmtCredit as ''Prepaid'' ,id.Amt50Tavi as ''TotalWHT'',id.TotalAmt as''Total Amount'',
0 as ''CN,DN Amount'',(CASE WHEN id.AmtAdvance>0 THEN id.TotalAmt ELSE 0 END) as ''Advance Amount'',(CASE WHEN id.AmtAdvance=0 THEN id.TotalAmt ELSE 0 END) as ''SVC Amount'',ISNULL(rd.ReceiptNet,0) as ''Payment Received'',
ISNULl(rd.LastRcvNo,'''') as ''Receipt No'',rd.LastRcvDate as ''Receipt Date''
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih 
on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company cu on ih.CustCode=cu.CustCode AND ih.CustBranch=cu.Branch 
inner join Job_ClearDetail cd
on id.BranchCode=cd.BranchCode and id.DocNo=cd.LinkBillNo
and id.ItemNo=cd.LinkItem
inner join Job_ClearHeader ch on cd.BranchCode=ch.BranchCode
and cd.ClrNo=ch.ClrNo
left join (
	SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,sum(d.Net) as ReceiptNet
	,Max(h.ReceiptNo) as LastRcvNo,Max(h.ReceiptDate) as LastRcvDate
	FROM Job_ReceiptDetail d inner join Job_ReceiptHeader h
	on d.BranchCode=h.BranchCode and d.ReceiptNo=h.ReceiptNo
	where NOT ISNULL(h.CancelProve,'''')<>'''' 
	group by d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
)rd on id.BranchCode=rd.BranchCode and id.DocNo=rd.InvoiceNo
and id.ItemNo=rd.InvoiceItemNo
where NOT ISNULL(ih.CancelProve,'''')<>'''' AND ISNULL(ch.DocStatus,0)<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'ReportNameEN', N'Billing Report By Customer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'ReportNameTH', N'รายงานติดตามการออกใบแจ้งหนี้ตามลูกค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode,,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'',d.ForJNo as ''Job Number'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''TotalVAT'', d.AmtWHT as ''TotalWHT'',
(CASE WHEN ISNULL(h.ApproveRef,'''')<>'''' THEN d.Total ELSE 0 END) as ''BILLED'',
(CASE WHEN ISNULL(h.ApproveRef,'''')='''' THEN d.Total ELSE 0 END) as ''UNBILLED'',
h.PoNo as ''Vender Inv#'',j.CustCode as ''Customer'',h.PaymentRef as ''Payment Ref#''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
LEFT JOIN Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch 
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'ReportNameEN', N'Payment By Vender by Job Order')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'ReportNameTH', N'รายงานค่าใช้จ่ายเจ้าหนี้ตามจ๊อบงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode,,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''TotalVAT'', d.AmtWHT as ''TotalWHT'',
d.Total as ''TotalNet'',d.ForJNo as ''Job Number'',j.CustCode as ''Customer'',
h.ApproveRef as ''Approve Ref#''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
LEFT JOIN Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch 
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' AND ISNULL(h.PaymentRef,'''')='''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'ReportNameEN', N'A/P Accural Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'ReportNameTH', N'รายงานค่าใช้จ่ายรอการจ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.CSCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode,e.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_SQL', N'select c.JNo as ''Job Number'',d.NameThai as ''Description'',a.AdvNo as ''Advance No'',
b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing date'',c.CustCode as ''Customer'',r.ReceiptNo as ''Receipt No'',r.ReceiptDate as ''Receipt Date'',
a.UsedAmount as ''Amount'',a.ChargeVAT as ''VAT Amount'',a.Tax50Tavi as ''WHT Amount'',(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Invoice Billed'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Invoice Unbilled'',a.LinkBillNo as ''Invoice No'',
i.DocDate as ''Invoice Date'',
(CASE WHEN b.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN b.ClearType=2 THEN ''COST'' ELSE ''SERV'' END) END) as ''Type''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
left join Job_InvoiceHeader i on a.BranchCode=i.BranchCode and a.LinkBillNo=i.DocNo
left join (
	SELECT hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,MAX(hd.ReceiptDate) as ReceiptDate,MAX(hd.ReceiptNo) as ReceiptNo
	FROM Job_ReceiptHeader hd INNER JOIN Job_ReceiptDetail dt
	ON hd.BranchCode=dt.BranchCode AND hd.ReceiptNo=dt.ReceiptNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo
) r on a.BranchCode=r.BranchCode and a.LinkBillNo=r.InvoiceNo AND a.LinkItem=r.InvoiceItemNo
where ISNULL(b.CancelProve,'''')='''' 
AND ISNULL(i.CancelProve,'''')='''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'ReportGroup', N'EXE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'ReportNameEN', N'A/R Accural Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'ReportNameTH', N'รายงานรายได้รอการวางบิล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_SQL', N'SELECT 
t.CustEName as ''Customer'',t.TaxNumber,(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,
t.ReceiptDate as ''Date'',t.ReceiptNo,t.TotalTransport as ''Transport'',t.TotalService as ''Service'',
t.TotalVat as ''Vat'',t.TotalAdvance as ''Advance'',t.TotalReceipt as ''Amt.Baht''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN c.NameEng ELSE ''**CANCEL** '' + c.NameEng END) as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 AND ISNULL(rh.CancelProve,'''')='''' THEN rd.Amt+rd.AmtVAT ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND ISNULL(rh.CancelProve,'''')='''' AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND ISNULL(rh.CancelProve,'''')='''' AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 THEN rd.AmtVat ELSE 0 END) as TotalVat,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0  THEN rd.Amt50Tavi ELSE 0 END) as TotalWhtax,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN rd.Net+rd.Amt50Tavi ELSE 0 END) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
left join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
left join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
left join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' AND rh.ReceiptType=''TAX'' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'ReportNameEN', N'Output TAX Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'ReportNameTH', N'รายงานภาษีมูลค่าเพิ่มตามใบกำกับภาษี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'ReportType', N'APL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_SQL', N'SELECT 
t.ReceiptDate as ''Date'',t.ReceiptNo,t.CustEName as ''Customer'',t.TaxNumber,
(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,t.TotalWhtax as ''WHD Tax''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,
CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''**CANCEL**''+ c.NameEng ELSE c.NameEng END as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 THEN rd.AmtVat ELSE 0 END) as TotalVat,
rh.Total50Tavi as TotalWhtax,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN rd.Net+rd.Amt50Tavi ELSE 0 END) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve,rh.Total50Tavi
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'ReportNameEN', N'Withholding TAX Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'ReportNameTH', N'รายงานหักภาษี ณ ที่จ่ายตามใบกำกับภาษี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'ReportType', N'APL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PAYREPORT', N'MAIN_SQL', N'select h.VenCode,h.ApproveRef,h.PaymentRef,h.PoNo,d.BookingRefNo,j.CustCode,j.DutyDate as InspectionDate,
c.Location,COUNT(distinct c.CTN_NO) as QTY,
SUM(CASE WHEN d.SICode=''CST-107'' THEN d.Amt ELSE 0 END)/COUNT(distinct c.CTN_NO) as UnitPrice,
SUM(CASE WHEN d.SICode NOT IN(''CST-107'',''ADV-177'') THEN d.Amt ELSE 0 END) as ExtraCharge,
SUM(CASE WHEN d.SICode=''CST-107'' THEN d.Amt ELSE 0 END) as Transport,
SUM(CASE WHEN d.SICode=''CST-107'' THEN d.Amt*s.Rate50Tavi*0.01 ELSE 0 END) as Tax50Tavi,
SUM(CASE WHEN d.SICode<>''CST-107'' THEN d.Total ELSE 0 END) as Others
FROM Job_PaymentDetail d inner join Job_PaymentHeader h
ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
inner join Job_SrvSingle s ON d.SIcode=s.SICode
inner join Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
inner join Job_LoadInfo b ON d.BranchCode=b.BranchCode AND d.BookingRefNo=b.BookingNo
left join Job_LoadInfoDetail c ON d.BranchCode=c.BranchCode AND d.BookingRefNo=c.BookingNo
AND h.BranchCode=c.BranchCode AND h.RefNo =c.CTN_NO
where ISNULL(h.CancelProve,'''')='''' {0}
group by h.VenCode,h.ApproveRef,h.PaymentRef,h.PoNo,d.BookingRefNo,j.CustCode,j.DutyDate,
c.Location')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_CLITERIA', N'WHERE,t.BookingDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.BookingDate,t.TotalContainer,t.TargetYardDate as PickUpTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t {0}  ORDER BY t.BookingDate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'ReportNameEN', N'Container Loading By Load Date')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'ReportNameTH', N'รายงานงานขนส่งตามวันโหลด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETDDate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=2 AND t.JobStatus<>99 {0} ORDER BY t.ETDDate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'ReportNameEN', N'Container Loading Export Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'ReportNameTH', N'รายงานลากตู้ขนส่งขาออก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETADate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0} ORDER BY t.ETADate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'ReportNameEN', N'Container Loading Import Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'ReportNameTH', N'รายงานการลากตู้ขนส่งขาเข้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3', N'ReportNameEN', N'PRD-3 Cover Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3', N'ReportNameTH', N'รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบปะหน้า)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3D', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3D', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3D', N'ReportNameEN', N'PRD-3 Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3D', N'ReportNameTH', N'รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบแนบ)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD3D', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53', N'ReportNameEN', N'PRD-53 Cover Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53', N'ReportNameTH', N'รายงานนำส่ง หัก ณ ที่จ่าย ภ.ง.ด.53 (ใบปะหน้า)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53D', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53D', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53D', N'ReportNameEN', N'PRD-53 Detail Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53D', N'ReportNameTH', N'รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.53 (ใบแนบ)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PRD53D', N'ReportType', N'STD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE ISNULL(a.PRType,''R'')=''P'' AND  NOT ISNULL(b.CancelProve,'''')<>''''
 ) t {0} ORDER BY VoucherDate,ControlNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'ReportNameEN', N'Payment Voucher Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'ReportNameTH', N'รายงานใบสำคัญจ่ายรายวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'ReportNameEN', N'Receipt Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'ReportNameTH', N'รายงานใบเสร็จรับเงินประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode,rd.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc ORDER BY rc.SDescription,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'ReportNameEN', N'Receipt Expense Detail')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'ReportNameTH', N'รายงานใบเสร็จรับเงินตามประเภท')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,
SUM(CASE WHEN rc.AmtAdvance>0 THEN rc.Amt+rc.AmtVAT ELSE 0 END) as TotalAdvance
,SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt+rc.AmtVAT ELSE 0 END) as TotalCharge
,SUM(rc.Amt50Tavi) as Amt50Tavi,
SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'''')='''' THEN 0 ELSE rc.Net END) as TotalReceived
FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'ReportNameEN', N'Receipt Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'ReportNameTH', N'รายงานสรุปใบเสร็จรับเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.DocNo<> ''''
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
    HAVING SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))<>''''
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE ISNULL(a.PRType,''R'')=''R'' AND NOT ISNULL(b.CancelProve,'''')<>''''
) t {0} ORDER BY VoucherDate,ControlNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'ReportNameEN', N'Receive Voucher Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'ReportNameTH', N'รายงานใบสำคัญรับรายวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'MAIN_CLITERIA', N'WHERE,,,,,,,,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'MAIN_SQL', N'SELECT SICode,NameThai,NameEng,StdPrice,DefaultVender,GLAccountCodeCost,GLAccountCodeSales,IsTaxCharge,Is50Tavi,Rate50Tavi,IsCredit,IsHaveSlip,IsExpense,GroupCode FROM Job_SrvSingle')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'ReportGroup', N'MAS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'ReportNameEN', N'Services Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'ReportNameTH', N'รายการรหัสงานบริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SERVICES', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'COLUMN_SUM', N',Extend Amt,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'MAIN_CLITERIA', N'AND,h.DocDate,h.CustCode,h.RefNo, h.EmpCode,,(CASE WHEN ISNULL(h.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),h.BranchCode,d.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'MAIN_SQL', N'SELECT * FROM (
select ''H'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
''MLI'' as ''AR Code'',
CAST(Year(h.DocDate) as varchar)+RIGHT(''0''+CAST(Month(h.DocDate) as varchar),2)+RIGHT(''0''+CAST(DAY(h.DocDate) as varchar),2) as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
''THB'' as ''Currency'',
c.LnNo as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(h.TotalNet+h.Total50Tavi) as ''Extend Amt'',
'''' as ''Account'',
'''' as ''Cost Center'',
'''' as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
''CLS'' as ''LOB'',
'''' as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
WHERE h.TotalNet>0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,j.CustPONo
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
''THB'' as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.Amt) as ''Extend Amt'',
ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales) as ''Account'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)<=''3'' THEN ''9762999'' ELSE c.GLAccountCode END) as ''Cost Center'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)=''6'' THEN ''INAS'' ELSE '''' END) as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
d.SDescription as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat>0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,j.CustPONo,d.SDescription,s.GLAccountCodeCost,s.GLAccountCodeSales,c.GLAccountCode
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
''THB'' as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.Amt) as ''Extend Amt'',
ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales) as ''Account'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)<=''3'' THEN ''9762999'' ELSE c.GLAccountCode END) as ''Cost Center'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)=''6'' THEN ''INAS'' ELSE '''' END) as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
d.SDescription as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat=0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,j.CustPONo,s.GLAccountCodeCost,s.GLAccountCodeSales,c.GLAccountCode,d.SDescription
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
''THB'' as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.AmtVat) as ''Extend Amt'',
''32406100'' as ''Account'',
''9762999'' as ''Cost Center'',
'''' as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
''VAT Amount (BASE '' + Cast(SUM(d.Amt) as varchar) + '')'' as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat>0 AND ISNULL(h.CancelProve,'''')='''' AND d.AmtCharge>0 {0}
GROUP BY c.LnNO,c.GLAccountCode,h.DocNo,j.CustPONo
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
''THB'' as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.AmtVat) as ''Extend Amt'',
''13608830'' as ''Account'',
''9762999'' as ''Cost Center'',
'''' as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
''VAT Amount (BASE '' + Cast(SUM(d.Amt) as varchar) + '')'' as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat>0 AND ISNULL(h.CancelProve,'''')='''' AND d.AmtAdvance>0 {0}
GROUP BY c.LnNO,c.GLAccountCode,h.DocNo,j.CustPONo
) t
ORDER BY 5')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'ReportNameEN', N'SAP AR Input Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'ReportNameTH', N'รายงานตั้งลูกหนี้ SAP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.BookCode,h.RecUser,,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_SQL', N'SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,
(CASE WHEN PRType=''P'' THEN CashAmount*-1 ELSE CashAmount END) as CashAmount,
(CASE WHEN PRType=''P'' THEN ChqAmount*-1 ELSE ChqAmount END) as ChqAmount,
(CASE WHEN PRType=''P'' THEN CreditAmount*-1 ELSE CreditAmount END) as ''Adjust Amount'',
(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount+CreditAmount)*-1 ELSE (CashAmount+ChqAmount+CreditAmount) END) as TotalNet,
ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) AND d.PRType<>'''' {0}
) as t ORDER BY BookCode,VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'ReportNameEN', N'Bank Statement')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'ReportNameTH', N'รายงานการรับจ่ายเงินตามสมุดบัญชี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)=''T'' {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'ReportNameEN', N'Tax-invoice Daily')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'ReportNameTH', N'รายงานใบกำกับภาษีประจำวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName as NameThai,rc.InvoiceNo,rc.JobNo,SUM(CASE WHEN rc.AmtAdvance>0 THEN rc.Net ELSE 0 END) as AmtAdvance,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt ELSE 0 END) as TotalCharge,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.AmtVAT ELSE 0 END) as AmtVAT,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt50Tavi ELSE 0 END) as Amt50Tavi,SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'''')='''' THEN 0 ELSE rc.Net END) as TotalReceived FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)=''T'' AND NOT ISNULL(rh.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'ReportGroup', N'RCV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'ReportNameEN', N'Tax-invoice Summary')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'ReportNameTH', N'รายงานสรุปใบกำกับภาษี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'MAIN_CLITERIA', N'AND,d.UnloadFinishDate, j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'MAIN_SQL', N'select h.JNo,h.BookingNo,j.CustCode,d.CTN_NO,d.SealNumber,d.CTN_SIZE,d.PlaceName2 as ''DeliveryPlace'',
d.Location as ''Route'',
FORMAT(CAST(d.TargetYardDate as DateTime)+CAST(CAST(ISNULL(d.TargetYardTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as PickupActual,
FORMAT(CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as DeliveryTarget,
FORMAT(CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as DeliveryActual,
DATEDIFF(mi,CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))/60 as DeliveryHour,
(CASE WHEN DATEDIFF(mi,CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))<=0 THEN 
''Early'' ELSE (CASE WHEN d.UnloadFinishDate IS NULL THEN ''Ongoing'' ELSE ''Late'' END) END) as DeliveryOntime,
FORMAT(CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as ActualReturn,
DATEDIFF(mi,CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))/60 as LoadingHour,
(CASE WHEN (DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60)>4 THEN ''Y'' ELSE ''N'' END) as LoadingOverTime,
(CASE WHEN ((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60)-4)>=3 THEN
((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60))-4
ELSE 0 END) as LoadingOverHour,
j.ForwarderCode as ''Agent'',d.Comment,h.VenderCode as ''Transporter'',d.Driver,
d.TruckNo,d.PlaceName1 as PickupPlace,d.PlaceName3 as ReturnPlace
FROM Job_LoadInfoDetail d INNER JOIN Job_Loadinfo h 
ON d.BranchCode=h.BranchCode AND d.BookingNo=h.BookingNo
INNER JOIN (SELECT *,(CASE WHEN JobType=1 THEN InvFCountry ELSE InvCountry END) as CountryCode FROM Job_Order) j ON h.BranchCode=j.BranchCode AND h.JNo=j.JNo
LEFT JOIN jobmaster.dbo.Mas_RFIPC p on j.InvInterPort=p.PortCode AND p.CountryCode=j.CountryCode
WHERE j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'ReportNameEN', N'Truck KPI Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'ReportNameTH', N'รายงานสรุปการปฏิบัติงานตามตู้คอนเทนเนอร์')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'MAIN_CLITERIA', N'WHERE,d.UnloadFinishDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'MAIN_SQL', N'SELECT h.BookingNo,j.JNo,c.CustCode,c.NameEng,d.ActualYardDate as PickupDate,
d.UnloadFinishDate as DeliveryDate,d.ReturnDate,h.VenderCode,a.AccTName,d.CTN_NO,d.CTN_SIZE,
(SELECT STUFF((
SELECT DISTINCT '',''+ LinkBillNo FROM Job_ClearDetail WHERE BranchCode=j.BranchCode AND JobNo=j.JNo
AND ISNULL(LinkBillNo,'''')<>'''' 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoCust,
(SELECT STUFF((
SELECT DISTINCT '',''+ ph.PoNo
FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
WHERE pd.BranchCode=h.BranchCode AND pd.ForJNo=h.JNo
AND pd.BookingRefNo=d.BookingNo and pd.BookingItemNo=d.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoVend,
CONVERT(numeric(10,2),e.TotalExpense) as TotalCost,clr.TotalInvoice as ''Invoice Billed'',clr.TotalInvoice-e.TotalExpense as ''Profit'',
j.CSCode,CONCAT(Year(j.DocDate),''/'',Month(j.DocDate)) as Period,jt.JobTypeName
FROM Job_Loadinfo h INNER JOIN Job_LoadInfoDetail d
ON h.BranchCode=d.BranchCode AND h.BookingNo =d.BookingNo
INNER JOIN Job_Order j on h.BranchCode=j.BranchCode
AND h.JNo=j.JNo LEFT JOIN Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN Mas_Account a ON c.GLAccountCode=a.AccCode
INNER JOIN (
SELECT Convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
LEFT JOIN
(
	select ch.BranchCode,ch.CTN_NO,
	SUM(cd.UsedAmount) as TotalInvoice,cd.JobNo
	from Job_ClearDetail cd inner join Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.ClrNo=ch.ClrNo
	where ch.DocStatus<>99
	AND ch.ClearType=3
	group by ch.BranchCode,ch.CTN_NO,cd.JobNo	
) clr
ON d.BranchCode=clr.BranchCode AND d.CTN_NO=clr.CTN_NO AND d.JNo=clr.JobNo
LEFT JOIN (
	SELECT pd.BranchCode,pd.BookingRefNo,pd.BookingItemNo,
	SUM(pd.Amt) as TotalExpense
	FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
	ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
	INNER JOIN Job_SrvSingle sv ON pd.SICode=sv.SICode 
	WHERE NOT ISNULL(ph.CancelProve,'''')<>'''' AND sv.IsCredit=0
	GROUP BY pd.BranchCode,pd.BookingRefNo,pd.BookingItemNo
) e ON d.BranchCode=e.BranchCode AND d.BookingNo=e.BookingRefNo AND d.ItemNo=e.BookingItemNo
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'ReportNameEN', N'Truck Summary Profit Report By Container')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'ReportNameTH', N'รายงานกำไรขาดทุนแต่ละตู้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'MAIN_CLITERIA', N'WHERE,d.UnloadFinishDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'MAIN_SQL', N'SELECT h.BookingNo,j.JNo,c.CustCode,c.NameEng,d.ActualYardDate as PickupDate,
d.UnloadFinishDate as DeliveryDate,d.ReturnDate,h.VenderCode,a.AccTName,d.CTN_NO,d.CTN_SIZE,
(SELECT STUFF((
SELECT DISTINCT '',''+ LinkBillNo FROM Job_ClearDetail WHERE BranchCode=j.BranchCode AND JobNo=j.JNo
AND LinkBillNo<>'''' 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoCust,
(SELECT STUFF((
SELECT DISTINCT '',''+ ph.PoNo
FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
WHERE pd.BranchCode=h.BranchCode AND pd.ForJNo=h.JNo
AND pd.BookingRefNo=d.BookingNo and pd.BookingItemNo=d.ItemNo AND ph.PaymentRef<>'''' 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoVend,
CONVERT(numeric(10,2),clr.TotalExpense) as TotalCost,clr.TotalInvoice as ''Invoice Billed'',clr.TotalInvoice-clr.TotalExpense as ''Profit'',
j.CSCode,CONCAT(Year(j.DocDate),''/'',Month(j.DocDate)) as Period,jt.JobTypeName
FROM Job_Loadinfo h INNER JOIN Job_LoadInfoDetail d
ON h.BranchCode=d.BranchCode AND h.BookingNo =d.BookingNo
INNER JOIN Job_Order j on h.BranchCode=j.BranchCode
AND h.JNo=j.JNo LEFT JOIN Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN Mas_Account a ON c.GLAccountCode=a.AccCode
INNER JOIN (
SELECT Convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
LEFT JOIN
(
	select r.LocationID,p.VenderCode,p.CustCode,
	SUM(p.CostAmount) as TotalExpense,
	SUM(p.ChargeAmount) as TotalInvoice 
	from Job_TransportRoute r inner join Job_TransportPrice p
	on r.LocationID=p.LocationID
	group by r.LocationID,p.VenderCode,p.CustCode
) clr
ON d.LocationID=clr.LocationID AND h.VenderCode=clr.VenderCode AND h.NotifyCode=clr.CustCode
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'ReportNameEN', N'Truck Summary Report By Container - Actual Delivery')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'ReportNameTH', N'รายงานกำไรขาดทุนแต่ละตู้ตามเป้าหมาย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-A', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'MAIN_CLITERIA', N'WHERE,d.UnloadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode,,c.CommLevel')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'MAIN_SQL', N'SELECT h.BookingNo,j.JNo,c.CustCode,c.NameEng,d.ActualYardDate as PickupDate,d.UnloadDate as DeliveryDateTarget,
d.UnloadFinishDate as DeliveryDateActual,d.ReturnDate,h.VenderCode,a.AccTName,d.CTN_NO,d.CTN_SIZE,
(SELECT STUFF((
SELECT DISTINCT '',''+ LinkBillNo FROM Job_ClearDetail WHERE BranchCode=j.BranchCode AND JobNo=j.JNo
AND LinkBillNo<>'''' AND LinkItem>0
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoCust,
(SELECT STUFF((
SELECT DISTINCT '',''+ ph.PoNo
FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
WHERE pd.BranchCode=h.BranchCode AND pd.ForJNo=h.JNo
AND pd.BookingRefNo=d.BookingNo and pd.BookingItemNo=d.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoVend,
CONVERT(numeric(10,2),clr.TotalExpense) as TotalCost,clr.TotalInvoice as ''Invoice Billed'',clr.TotalInvoice-clr.TotalExpense as ''Profit'',
j.CSCode,CONCAT(Year(j.DocDate),''/'',Month(j.DocDate)) as Period,jt.JobTypeName
FROM Job_Loadinfo h INNER JOIN Job_LoadInfoDetail d
ON h.BranchCode=d.BranchCode AND h.BookingNo =d.BookingNo
INNER JOIN Job_Order j on h.BranchCode=j.BranchCode
AND h.JNo=j.JNo LEFT JOIN Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN Mas_Account a ON c.GLAccountCode=a.AccCode
INNER JOIN (
SELECT Convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
LEFT JOIN
(
	select r.LocationID,p.VenderCode,p.CustCode,
	SUM(p.CostAmount) as TotalExpense,
	SUM(p.ChargeAmount) as TotalInvoice 
	from Job_TransportRoute r inner join Job_TransportPrice p
	on r.LocationID=p.LocationID
	group by r.LocationID,p.VenderCode,p.CustCode
) clr
ON d.LocationID=clr.LocationID AND h.VenderCode=clr.VenderCode AND h.NotifyCode=clr.CustCode
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'ReportGroup', N'JOB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'ReportNameEN', N'Truck Summary Report By Container - Target Delivery')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'ReportNameTH', N'รายงานกำไรขาดทุนแต่ละตู้ตามสถานะจริง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKSUM-T', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'MAIN_CLITERIA', N'WHERE,,,,,,,,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'MAIN_SQL', N'SELECT UserID,TName,EName,TPosition,MobilePhone,EMail,UPassword,UPosition FROM Mas_User')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'ReportGroup', N'MAS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'ReportNameEN', N'User Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'ReportNameTH', N'รายชื่อผู้ใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_USERS', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_CLITERIA', N'WHERE,t.ExpenseDate,t.CustCode,t.JobNo,,t.VenCode,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_SQL', N'SELECT ExpenseDate,SlipNo,VenderName,TaxNumber,Branch,ExpenseAmt,ExpenseVAT,CancelReson FROM (
SELECT cd.Date50Tavi as ExpenseDate, cd.SlipNO as SlipNo, v.TName as VenderName, v.TaxNumber, v.BranchCode as Branch, v.VenCode, cd.UsedAmount as ExpenseAmt, cd.ChargeVAT as ExpenseVAT, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.PaymentDate IS NOT NULL) AND (cd.SlipNO <> '''')
UNION
SELECT h.CancelDate, ''*''+cd.SlipNO, v.TName + ''**ยกเลิก**'', v.TaxNumber, v.BranchCode, v.VenCode, 0, 0, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.CancelDate IS NOT NULL) AND (cd.SlipNO <> '''')
) AS t {0} ORDER BY ExpenseDate,SlipNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'ReportNameEN', N'Purchase VAT Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'ReportNameTH', N'รายงานภาษีซื้อ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_CLITERIA', N'WHERE,t.ReceiptDate,t.CustCode,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_SQL', N'SELECT ReceiptDate,ReceiptNo,ServiceType,TaxNumber,Branch,TotalChargeVAT,TotalVAT,TotalChargeNonVAT,CancelReson FROM (
SELECT h.ReceiptDate,h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
d.TotalVATCharge as TotalChargeVAT,
d.TotalVAT,
d.TotalNonVAT as TotalChargeNonVAT,
d.TotalCharge+d.TotalVAT as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h inner join (
	SELECT a.BranchCode,a.ReceiptNo,
	SUM(CASE WHEN b.AmtCharge>0 THEN a.Amt ELSE 0 END) as TotalCharge,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT>0 THEN a.Amt ELSE 0 END) as TotalVATCharge,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT=0 THEN a.Amt ELSE 0 END) as TotalNonVAT,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT=0 THEN a.AmtVAT ELSE 0 END) as TotalVAT
	FROM Job_ReceiptDetail a INNER JOIN Job_InvoiceDetail b ON a.BranchCode=b.BranchCode 
	AND a.InvoiceNo=b.DocNo AND a.InvoiceItemNo=b.ItemNo     
	GROUP BY a.BranchCode,a.ReceiptNo
) d ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE NOT ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.DocDate,h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
CASE WHEN d.VATAmt <>0 THEN d.DiffAmt ELSE 0 END as TotalChargeVAT,
d.VATAmt,
CASE WHEN d.VATAmt =0 THEN d.DiffAmt ELSE 0 END as TotalChargeNonVAT,
d.DiffAmt+d.VATAmt as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE  NOT h.DocStatus<>99
UNION
SELECT h.CancelDate,''*''+h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVat,
0 as TotalChargeNonVAT,
0 as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE  SUBSTRING(h.ReceiptType,1,1)=''T'' AND ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.CancelDate,''*''+h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVAT,
0 as TotalNonVAT,
0 as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.DocStatus<>99
) AS t {0} ORDER BY ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'ReportNameEN', N'Sales VAT Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'ReportNameTH', N'รายงานภาษีขาย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'MAIN_CLITERIA', N'WHERE,,,,,,,,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'MAIN_SQL', N'SELECT VenCode,BranchCode,TaxNumber,TName,English,TAddress1+''<br/>''+TAddress2 as TAddress,
EAddress1+''<br/>''+EAddress2 as EAddress,Phone,FaxNumber,LoginName,LoginPassword FROM Mas_Vender')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'ReportAuthor', N'1,6,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'ReportGroup', N'MAS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'ReportNameEN', N'Vender Lists')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'ReportNameTH', N'รายชื่อผู้ให้บริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDERS', N'ReportType', N'EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDSUMMARY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDSUMMARY', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDSUMMARY', N'ReportNameEN', N'Vender Summary Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDSUMMARY', N'ReportNameTH', N'รายงานสรุปจ่ายเจ้าหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VENDSUMMARY', N'ReportType', N'FIX')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_CLITERIA', N'AND,cd.Date50Tavi,c.CustCode,cd.JobNo,ch.EmpCode,cd.VenderCode,,ch.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_SQL', N'SELECT Date50Tavi,NO50Tavi,VenTaxNumber,VenTaxBranch,VenderName,CustTaxNumber,CustName,
(CASE WHEN Tax50TaviRate =1 THEN ''ค่าขนส่ง'' ELSE (CASE WHEN (Tax50TaviRate=1.5 OR Tax50TaviRate=3) THEN ''ค่าบริการ'' ELSE (CASE WHEN Tax50TaviRate =5 THEN ''ค่าเช่า'' ELSE (CASE WHEN Tax50TaviRate =2 THEN ''ค่าโฆษณา'' ELSE (CASE WHEN Tax50TaviRate =10 THEN ''ออกให้มูลนิธิ/สมาคม'' ELSE ''เงินเดือน'' END) END) END) END) END) as TaxType,
(CASE WHEN CustName Like ''%จำกัด%'' THEN ''ภงด53'' ELSE ''ภงด3'' END) as TaxForm,
(CASE WHEN IsLtdAdv50Tavi=1 THEN Tax50Tavi ELSE 0 END) as Tax3Tres,
(CASE WHEN IsLtdAdv50Tavi=0 THEN Tax50Tavi ELSE 0 END) as TaxNot3Tres,
SlipNO,UsedAmount,Tax50TaviRate
FROM (
SELECT cd.Date50Tavi, cd.NO50Tavi, v.VenCode, v.TaxNumber AS VenTaxNumber, v.BranchCode AS VenTaxBranch, v.TName AS VenderName, c.CustCode, 
    c.TaxNumber AS CustTaxNumber, c.Branch AS CustTaxBranch, c.NameThai AS CustName, cd.SICode, cd.SDescription, cd.UsedAmount, cd.Tax50TaviRate, 
    cd.Tax50Tavi, cd.IsLtdAdv50Tavi, cd.SlipNO
FROM     dbo.Job_ClearDetail AS cd INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch INNER JOIN
    dbo.Mas_Vender AS v ON cd.VenderCode = v.VenCode
WHERE (cd.Tax50Tavi > 0) AND ch.DocStatus<>99 {0}
) as t ORDER BY 9,1,2')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'ReportGroup', N'CLR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'ReportNameEN', N'Withholding-Tax Clearing Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'ReportNameTH', N'รายงานหัก ณ ที่จ่ายจากการปิดค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_CLITERIA', N'AND,h.DocDate,h.TaxNumber1,d.JNo,h.UpdateBy,h.TaxNumber3,h.FormType,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_SQL', N'SELECT FormTypeName,TaxLawName,TaxNumber1 as TaxNumber,Branch1 as Branch,TName1 as TaxBy,
Year(a.DocDate) as TaxYear,Month(a.DocDate)  as TaxMonth,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayAmount END) as ServiceAmount,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayTax END) as TaxService, 
SUM(CASE WHEN a.PayRate>1 THEN 0 ELSE a.PayAmount END) as TranAmount,
SUM(CASE WHEN a.PayRate>1 THEN 0 ELSE a.PayTax END) as TaxTransport
FROM
(
    SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
    d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
    j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
    (CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
    (CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
    FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
    ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
    LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
    AND d.JNo=j.JNo 
    LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
	LEFT JOIN dbo.Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
    WHERE NOT ISNULL(h.CancelProve,'''')<>'''' 
	{0}
) a 
GROUP BY FormTypeName,TaxLawName,TaxNumber1,Branch1,Year(a.DocDate),Month(a.DocDate),TName1
ORDER BY FormTypeName,TName1,Year(a.DocDate),Month(a.DocDate)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'ReportNameEN', N'Withholding-Tax Summary Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'ReportNameTH', N'รายงานสรุปการออกหนังสือหัก ณ ที่จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_CLITERIA', N'AND,h.DocDate,h.TaxNumber1,h.JNo,h.UpdateBy,h.TaxNumber3,h.FormType,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_SQL', N'SELECT a.DocDate,a.DocNo,a.TName1 as TaxBy,a.TName3 as TaxFor,a.FormTypeName,a.TaxLawName,a.PayTaxDesc,a.PayRate,a.PayAmount as Amount,a.PayTax FROM (
SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
(CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
(CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
AND d.JNo=j.JNo 
LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' 
{0}
) a order by a.DocDate,a.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'ReportAuthor', N'1,2,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'ReportGroup', N'FIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'ReportNameEN', N'Withholding-Tax Issue Report')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'ReportNameTH', N'รายงานการออกหนังสือหัก ณ ที่จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'ReportType', N'ADD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'APP_PAY', N'yy-____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'APP_PETTYCASH', N'yyMM____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'BILL', N'yy_____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'INV', N'yy_____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'QUO', N'yy-____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'RCP', N'yy_____')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'ADV', N'ADV-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'APP_PAY', N'[VEN]-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'APP_PETTYCASH', N'CTIS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'BILL', N'APLL-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_ADV', N'CLR-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_COST', N'CST-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_SERV', N'SRV-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'EXP', N'ACC-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'INV', N'IVS-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'PAY', N'PAY-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'QUO', N'APLL-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_ADV', N'REC-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_RCV', N'REC-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_REC', N'REC-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_SRV', N'TAX-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_TAX', N'TAX-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'WHTAX', N'WT-')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'EXP', N'Expenses')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'INC', N'Income')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'STD', N'Standard Services')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'10', N'LOCAL - CUSTOMS')
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
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvClear', N'select a.BranchCode,a.AdvNo,a.AdvBy,a.AdvDate,a.TotalAdvance,a.MainCurrency,c.ClrNo,b.ClrDate,
c.JobNo,j.DutyDate,j.CSCode,c.SDescription,d.GLAccountCode as CostCenter,
ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales) as AccountCode,c.Tax50TaviRate,c.VATRate,
c.UsedAmount,c.ChargeVAT,c.Tax50Tavi,c.BNet,b.DocStatus
from Job_AdvHeader a inner join Job_ClearDetail c
on a.BranchCode=c.BranchCode 
and a.AdvNo=c.AdvNO
inner join Job_ClearHeader b
on c.BranchCode=b.BranchCode 
and c.ClrNo=b.ClrNo
inner join Job_Order j
on c.BranchCode=j.BranchCode 
and c.JobNo=j.JNo
inner join Mas_Company d
on j.CustCode=d.CustCode AND j.CustBranch=d.Branch
inner join Job_SrvSingle e
on c.SICode=e.SICode
where b.DocStatus<>99 {0}
order by j.DutyDate,j.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvDetail', N'select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvForClear', N'Select a.BranchCode,'''' as ClrNo,0 as ItemNo,0 as LinkItem,
a.STCode,a.SICode,a.SDescription,a.VenCode as VenderCode,
a.AdvQty as Qty,b.UnitCharge as UnitCode,a.CurrencyCode,a.ExchangeRate as CurRate,
(CASE WHEN b.IsExpense=0 THEN a.UnitPrice ELSE 0 END) as UnitPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice ELSE 0 END) as FPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice*a.ExchangeRate ELSE 0 END) as BPrice,
q.TotalCharge as QUnitPrice,a.AdvQty*q.ChargeAmt as QFPrice,a.AdvQty*q.ChargeAmt*q.CurrencyRate as QBPrice,
a.UnitPrice as UnitCost,a.AdvQty*a.UnitPrice as FCost,a.AdvQty*a.UnitPrice*a.ExchangeRate as BCost,
a.ChargeVAT,a.Charge50Tavi as Tax50Tavi,a.AdvNo as AdvNO,d.AdvDate,a.ItemNo as AdvItemNo,a.AdvAmount,a.AdvNet,
a.AdvNet-ISNULL(d.TotalCleared,0) as AdvBalance,ISNULL(d.TotalCleared,0) as UsedAmount,
(CASE WHEN ISNULL(q.QNo,'''')='''' THEN 0 ELSE 1 END) as IsQuoItem,
a.IsDuplicate,b.IsExpense,
b.IsLtdAdv50Tavi,(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN '''' ELSE a.PayChqTo END) as Pay50TaviTo,a.Doc50Tavi as NO50Tavi,NULL as Date50Tavi,
(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN a.PayChqTo ELSE '''' END) as VenderBillingNo,'''' as SlipNO,'''' as Remark,
(SELECT STUFF((
	SELECT DISTINCT '','' + Convert(varchar,QtyBegin) + ''-''+convert(varchar,QtyEnd)+''=''+convert(varchar,ChargeAmt)
	FROM Job_QuotationItem WHERE BranchCode=q.BranchCode
	AND QNo=q.QNo AND SICode=q.SICode AND VenderCode =q.VenderCode
	AND UnitCheck=q.UnitCheck AND CalculateType=1
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AirQtyStep,q.CalculateType as StepSub,
a.ForJNo as JobNo,a.IsChargeVAT as VATType,a.VATRate,a.Rate50Tavi as Tax50TaviRate,q.QNo,
c.DocStatus,c.AdvBy,c.EmpCode as ReqBy,c.PaymentDate,c.CustCode,c.PaymentRef
FROM Job_AdvDetail a LEFT JOIN Job_SrvSingle b on a.SICode=b.SICode
INNER JOIN Job_AdvHeader c on a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo 
left join Job_Order j on a.BranchCode=j.BranchCode and a.ForJNo=j.JNo
left join 
(
	select qh.BranchCode,qh.QNo,
	qd.JobType,qd.ShipBy,qd.SeqNo,
	qi.ItemNo,qi.SICode,qi.CalculateType,
	qi.QtyBegin,qi.QtyEnd,qi.UnitCheck,qi.CurrencyCode,
	qi.CurrencyRate,qi.ChargeAmt,qi.Isvat,qi.VatRate,
	qi.VatAmt,qi.IsTax,qi.TaxRate,qi.TaxAmt,
	qi.TotalAmt,qi.TotalCharge,qi.UnitDiscntPerc,qi.UnitDiscntAmt,
	qi.VenderCode,qi.VenderCost,qi.BaseProfit,qi.CommissionPerc,qi.CommissionAmt,
	qi.NetProfit,qi.IsRequired
	from Job_QuotationHeader qh	inner join Job_QuotationDetail qd ON qh.BranchCode=qd.BranchCode and qh.QNo=qd.QNo
	inner join Job_QuotationItem qi	on qd.BranchCode=qi.BranchCode and qd.QNo=qi.QNo and qd.SeqNo=qi.SeqNo 
    where qh.DocStatus=3 
) q
on a.BranchCode=q.BranchCode and b.SICode=q.SICode and ISNULL(a.VenCode,b.DefaultVender)=q.VenderCode 
and b.UnitCharge=q.UnitCheck and a.AdvQty <=q.QtyEnd and a.AdvQty>=q.QtyBegin and q.QNo=j.QNo
left join 
(
	SELECT ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,
    SUM(ISNULL(cd.BNet,0)) as TotalCleared    
	FROM Job_ClearDetail cd INNER JOIN Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode	and cd.ClrNo =ch.ClrNo 	and ch.DocStatus<>99
    INNER JOIN Job_AdvDetail ad on cd.BranchCode=ad.BranchCode and cd.AdvNO=ad.AdvNo and cd.AdvItemNo=ad.ItemNo
    INNER JOIN Job_AdvHeader ah on ad.BranchCode=ah.BranchCode and ad.AdvNo=ah.AdvNo
    WHERE ah.DocStatus<>99 AND ch.DocStatus<>99 
	GROUP BY ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,ad.IsDuplicate,ad.AdvNet
) d
ON a.BranchCode=d.BranchCode and a.AdvNo=d.AdvNo and a.ItemNo=d.ItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvForWhTax', N'select BranchCode,AdvNo,(CASE WHEN Rate50Tavi=1 THEN ''ค่าขนส่ง 1%'' ELSE CONCAT(''ค่าบริการ '',Rate50Tavi,''%'') END) as SDescription,
SUM(AdvAmount) as AdvAmount,SUM(Charge50Tavi) as Charge50Tavi
,MAX(ForJNo) as ForJNo,Rate50Tavi 
from Job_AdvDetail where Rate50Tavi>0 {0}
group by BranchCode,AdvNo,Rate50Tavi')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvHeader', N'select a.*,
(SELECT STUFF((
    SELECT DISTINCT '','' + ForJNo
    FROM Job_AdvDetail WHERE BranchCode=a.BranchCode
    AND AdvNo=a.AdvNo AND ForJNo<>'''' 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo
,
(SELECT STUFF((
    SELECT DISTINCT '','' + InvNo
    FROM Job_Order WHERE BranchCode=a.BranchCode AND JNo in(SELECT ForJNo FROM Job_AdvDetail WHERE BranchCode=a.BranchCode
    AND AdvNo=a.AdvNo AND ForJNo<>'''')
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as CustInvNo
,b.TaxNumber,b.NameThai,b.NameEng
,c.BaseAmount,c.RateVAT,c.Rate50Tavi,c.BaseVATInc,c.Base50TaviInc,c.BaseVATExc,c.Base50TaviExc
,c.BaseVATInc+c.BaseVATExc as BaseVAT,c.Base50TaviExc+c.Base50TaviInc as Base50Tavi
,c.VATInc,c.VATExc,c.WHTInc,c.WHTExc,c.TotalNet
,a.AdvCash*a.ExchangeRate as AdvCashCal
,a.AdvChq*a.ExchangeRate as AdvChqCal
,a.AdvChqCash*a.ExchangeRate as AdvChqCashCal
,a.AdvCred*a.ExchangeRate as AdvCredCal
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT BranchCode,AdvNo,MAX(VATRate) as RateVAT,MAX(Rate50Tavi) as Rate50Tavi,
    SUM(CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    SUM(CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    SUM(CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    SUM(CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    SUM(CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    SUM(CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    SUM(CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    SUM(CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc,
    SUM(AdvAmount) as BaseAmount,SUM(AdvNet) as TotalNet  
    FROM Job_AdvDetail 
    GROUP BY BranchCode,AdvNo
) c
ON a.BranchCode=c.BranchCode AND a.AdvNo=c.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvReport', N'SELECT dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectAdvSumClear', N'select a.BranchCode,a.AdvNo,ISNULL(f.AccTName,'''') + '' / ''+ ISNULL(g.AccTName,'''') as GLDesc,
d.GLAccountCode as CostCenter,
ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales) as AccountCode,
SUM(c.UsedAmount) as Amt,SUM(c.ChargeVAT) as Vat,SUM(c.Tax50Tavi) as Wht,SUM(c.BNet) as Net
from Job_AdvHeader a inner join Job_ClearDetail c
on a.BranchCode=c.BranchCode 
and a.AdvNo=c.AdvNO
inner join Job_ClearHeader b
on c.BranchCode=b.BranchCode 
and c.ClrNo=b.ClrNo
inner join Job_Order j
on c.BranchCode=j.BranchCode 
and c.JobNo=j.JNo
inner join Mas_Company d
on j.CustCode=d.CustCode AND j.CustBranch=d.Branch
inner join Job_SrvSingle e
on c.SICode=e.SICode
left join Mas_Account f on f.AccCode=d.GLAccountCode
left join Mas_Account g on g.AccCode=ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales)
where b.DocStatus<>99 {0}
group by a.BranchCode,a.AdvNo,f.AccTName,g.AccTName,
d.GLAccountCode,ISNULL(e.GLAccountCodeCost,e.GLAccountCodeSales)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectBillDetail', N'SELECT a.BranchCode, a.BillAcceptNo, a.ItemNo, a.InvNo, a.AmtAdvance, a.AmtChargeNonVAT, a.AmtChargeVAT, a.AmtWH, a.AmtVAT, a.AmtTotal, a.CurrencyCode, 
a.ExchangeRate, a.AmtCustAdvance, a.AmtForeign, a.InvDate, a.RefNo, a.AmtVATRate, a.AmtWHRate, a.AmtDiscount, a.AmtDiscRate, b.DocDate, b.CustCode, 
b.CustBranch, b.BillToCustCode, b.BillToCustBranch, b.ContactName, b.EmpCode, b.PrintedBy, b.PrintedDate, b.PrintedTime, b.VATRate, b.TotalAdvance, 
b.TotalCharge, b.TotalIsTaxCharge, b.TotalIs50Tavi, b.TotalVAT, b.Total50Tavi, b.TotalCustAdv, b.TotalNet, b.ForeignNet, b.BillAcceptDate, b.BillIssueDate, 
b.Remark1, b.Remark2, b.Remark3, b.Remark4, b.Remark5, b.Remark6, b.Remark7, b.Remark8, b.Remark9, b.Remark10, b.CancelReson, b.CancelProve, 
b.CancelDate, b.CancelTime, b.ShippingRemark, b.SumDiscount, b.DiscountRate, b.DiscountCal, b.TotalDiscount, b.DueDate, b.CreateDate, c.TaxNumber, 
c.Title + '''' + c.NameThai AS CustTName, c.NameEng AS CustEName,d.Total50Tavi1 as AmtWH1,d.Total50Tavi3 as AmtWH3
FROM dbo.Job_BillAcceptDetail AS a INNER JOIN
dbo.Job_InvoiceHeader AS b ON a.BranchCode = b.BranchCode AND a.InvNo = b.DocNo 
INNER JOIN (SELECT BranchCode,DocNo,
SUM(CASE WHEN Rate50Tavi=1 THEN Amt50Tavi ELSE 0 END) as Total50Tavi1,
SUM(CASE WHEN Rate50Tavi=1 THEN 0 ELSE Amt50Tavi END) as Total50Tavi3
FROM Job_InvoiceDetail GROUP BY BranchCode,DocNo) d
ON b.BranchCode=d.BranchCode AND b.DocNo=d.DocNo
INNER JOIN
dbo.Mas_Company AS c ON b.CustCode = c.CustCode AND b.CustBranch = c.Branch')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectBillReport', N'SELECT h.BranchCode, h.BillAcceptNo, h.BillDate, h.CustCode, h.CustBranch, h.BillRecvBy, h.BillRecvDate, h.DuePaymentDate, h.BillRemark, h.CancelReson, 
h.CancelProve, h.CancelDate, h.CancelTime, h.EmpCode, h.RecDateTime, h.TotalCustAdv, h.TotalAdvance, h.TotalChargeVAT, h.TotalChargeNonVAT, h.TotalVAT, 
h.TotalWH, h.TotalDiscount, h.TotalNet, d.ItemNo, d.InvNo, d.AmtAdvance, d.AmtChargeNonVAT, d.AmtChargeVAT, d.AmtWH, d.AmtVAT, d.AmtTotal, d.CurrencyCode, 
d.ExchangeRate, d.AmtCustAdvance, d.AmtForeign, d.InvDate, d.RefNo, d.AmtVATRate, d.AmtWHRate, d.AmtDiscount, d.AmtDiscRate
FROM dbo.Job_BillAcceptHeader AS h INNER JOIN
dbo.Job_BillAcceptDetail AS d ON h.BranchCode = d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo AND ISNULL(h.CancelProve,'''')=''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectBookAccBalance', N'SELECT q.*,q.SumCashOnhand+q.SumChqClear as SumCash,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand-q.LimitBalance as SumCashInBank,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand+q.SumCredit as SumBal,
q.SumCredit+q.SumChqReturn as SumCreditable
FROM (
select c.BookCode,c.LimitBalance,c.ControlBalance,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount) else a.CashAmount end) as SumCashOnhand,
Sum(Case when a.ChqStatus=''P'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqClear,
Sum(Case when a.ChqStatus=''R'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqReturn,
Sum(Case when a.ChqStatus NOT IN(''P'',''R'') then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqOnhand,
Sum(Case when a.PRType=''P'' then -1*a.CreditAmount else a.CreditAmount end) as SumCredit,
Sum(Case when a.PRType=''P'' then -1*(a.CreditAmount) else 0 end) as SumAP,
Sum(Case when a.PRType=''R'' then (a.CreditAmount) else 0 end) as SumAR,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount+a.ChqAmount) else 0 end) as SumPV,
Sum(Case when a.PRType=''R'' then (a.CashAmount+a.ChqAmount) else 0 end) as SumRV
from Job_CashControlSub a inner join Job_CashControl b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo
left join Mas_BookAccount c 
on a.BookCode=c.BookCode
WHERE ISNULL(b.CancelProve,'''')='''' {0}
group by c.BookCode,c.LimitBalance,c.ControlBalance) q')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectBooking', N'SELECT h.BranchCode, h.JNo, h.BookingNo, h.LoadDate AS BookingDate, h.NotifyCode, h.VenderCode AS ForwarderCode, h.ContactName AS ShipperContact, 
u.TName AS CSName, u.MobilePhone AS CSTel, u.EMail AS CSEMail, j.InvNo, j.InvProduct, j.InvProductQty, j.InvProductUnit,j.InvCurUnit,j.InvCurRate, j.TotalContainer, j.ShippingCmd,
a.English AS ForwarderName, a.EAddress1 AS ForwarderAddress1, a.EAddress2 AS ForwarderAddress2, a.ContactSale AS ForwarderContact, a.TaxNumber as ForwarderTaxID,
a.Phone AS ForwarderPhone, c.NameEng AS ConsigneeName, c.EAddress1 AS ConsignAddress1, c.EAddress2 AS ConsignAddress2, c.Phone AS ConsignPhone, c.FaxNumber as ConsignFax,c.DMailAddress as ConsignEmail,c.TaxNumber as ConsignTaxID,c.Branch as ConsignTaxBranch,
n.NameEng AS NotifyName, n.EAddress1 AS NotifyAddress1, n.EAddress2 AS NotifyAddress2, n.Phone AS NotifyPhone, n.FaxNumber as NotifyFax,n.DMailAddress as NotifyEmail, n.TaxNumber as NotifyTaxID,n.Branch as NotifyTaxBranch,
j.VesselName, j.MVesselName, j.ProjectName, j.TotalGW, j.TotalNW , j.GWUnit, j.InvInterPort, j.InvFCountry, j.InvCountry, j.ETDDate, j.ETADate, j.ClearPortNo, j.ClearPort, j.DeliveryTo, j.DeliveryAddr, 
j.ShippingEmp,e.TName as ShippingName, e.MobilePhone as ShippingTel,j.TRemark, j.EstDeliverDate, h.Remark, h.PackingAddress, h.CYAddress, h.FactoryAddress, h.ReturnAddress, h.PackingContact, h.CYContact, h.FactoryContact, h.ReturnContact, 
h.PackingPlace, h.CYPlace, h.FactoryPlace, h.ReturnPlace, h.PackingDate, h.CYDate, h.FactoryDate, h.ReturnDate, h.PackingTime, h.CYTime, h.FactoryTime, 
h.ReturnTime, h.TransMode, h.PaymentCondition, h.PaymentBy, d.CTN_NO, d.SealNumber, d.TruckNO, d.Comment, d.TruckType, d.Driver, d.Location, d.DeliveryNo,
d.ShippingMark, d.CTN_SIZE, d.ProductDesc, d.ProductQty, d.ProductUnit, d.GrossWeight, d.Measurement, d.TargetYardDate, d.TargetYardTime, d.ActualYardDate, d.ActualYardTime, 
d.UnloadDate AS TargetDeliveryDate, d.UnloadTime as TargetDeliveryTime, d.UnloadFinishDate AS ActualDeliveryDate, d.UnloadFinishTime as ActualDeliveryTime,
d.TruckIN AS TargetReturnDate, d.Start as TargetReturnTime, d.ReturnDate AS ActualReturnDate, d.Finish as ActualReturnTime, j.BLNo, j.JobType, 
j.ShipBy, j.AgentCode, s.NameEng AS ShipperName, s.EAddress1 AS ShipperAddress1, s.EAddress2 AS ShipperAddress2, s.Phone AS ShipperPhone, s.FaxNumber as ShipperFax, s.DMailAddress as ShipperEMail,
s.TaxNumber as ShipperTaxID,s.Branch as ShipperTaxBranch,j.AgentCode AS TransportCode, j.ForwarderCode AS CarrierCode, v.English AS CarrierName, v.EAddress1 AS CarrierAddress1, v.EAddress2 AS CarrierAddress2, 
v.ContactSale AS CarrierContact, v.Phone AS CarrierPhone,v.TaxNumber as CarrierTaxID, t.English AS TransportName, t.EAddress1 AS TransportAddress1, t.EAddress2 AS TransportAddress2, 
t.ContactSale AS TransportContact, t.Phone AS TransportPhone,t.TaxNumber as TransportTaxID, j.CustContactName, j.Measurement AS TotalM3, j.HAWB, j.MAWB, j.Description, j.CustRefNO,j.ConfirmDate,
r.LocationRoute,d.PlaceName1,d.PlaceAddress1,PlaceContact1,d.PlaceName2,d.PlaceAddress2,PlaceContact2,d.PlaceName3,d.PlaceAddress3,PlaceContact3,d.PlaceName4,d.PlaceAddress4,PlaceContact4
FROM dbo.Mas_Company AS n INNER JOIN
dbo.Mas_Vender AS a INNER JOIN
dbo.Job_LoadInfo AS h LEFT OUTER JOIN
dbo.Job_LoadInfoDetail AS d ON h.BranchCode = d.BranchCode AND h.BookingNo = d.BookingNo ON a.VenCode = h.VenderCode ON 
n.CustCode = h.NotifyCode LEFT OUTER JOIN
dbo.Job_TransportRoute AS r ON d.LocationID = r.LocationID INNER JOIN
dbo.Job_Order AS j ON h.BranchCode = j.BranchCode AND h.JNo = j.JNo INNER JOIN
dbo.Mas_User AS u ON j.CSCode = u.UserID LEFT OUTER JOIN
dbo.Mas_User AS e ON j.ShippingEmp = e.UserID LEFT OUTER JOIN
dbo.Mas_Vender AS v ON j.ForwarderCode = v.VenCode LEFT OUTER JOIN
dbo.Mas_Vender AS t ON j.AgentCode = t.VenCode LEFT OUTER JOIN
dbo.Mas_Company AS c ON j.consigneecode = c.CustCode LEFT OUTER JOIN
dbo.Mas_Company AS s ON j.CustCode = s.CustCode AND j.CustBranch = s.Branch
WHERE (j.JobStatus < 90)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectCashFlow', N'SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectChequeBalancePCH', N'SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.BankCode,h.BankBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.BankCode,h.BankBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch 
WHERE a.acType=''CH''
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectChequeBalancePCU', N'SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch
left join (
	SELECT h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch
WHERE a.acType=''CU''
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectChequeBalanceRCH', N'SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.BankCode,h.BankBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch
left join (
	SELECT h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.BankCode,h.BankBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch 
WHERE a.acType=''CH''
AND a.PRType=''R'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectChequeBalanceRCU', N'SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch
left join (
	SELECT h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU''
AND a.PRType=''R'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClearExp', N'SELECT a.BranchCode,a.JNo,a.SICode,a.SDescription,a.TRemark,a.AmountCharge,a.Status,
a.CurrencyCode,a.ExchangeRate,a.Qty,a.QtyUnit,a.AmtVatRate,a.AmtVat,a.AmtWhtRate,a.AmtWht,
a.AmtTotal,b.ClrNo,b.CostAmount,b.ChargeAmount
FROM dbo.Job_ClearExp a
LEFT JOIN (
SELECT BranchCode,JobNo,SICode,SUM(BCost) as CostAmount,SUM(BPrice) as ChargeAmount,Max(ClrNo) as ClrNo
FROM dbo.Job_ClearDetail WHERE ClrNo NOT IN (SELECT ClrNo FROM Job_ClearHeader WHERE DocStatus=99)
GROUP BY BranchCode,JobNo,SICode
) b
ON a.BranchCode=b.BranchCode AND a.JNo=b.JobNo AND a.SICode=b.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClrDetail', N'select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClrForInvoice', N'select b.BranchCode,b.LinkBillNo as DocNo,b.LinkItem as ItemNo,b.SICode,b.SDescription,
b.SlipNO as ExpSlipNO,b.Remark as SRemark,b.CurrencyCode,
b.CurRate as ExchangeRate,b.Qty,b.UnitCode as QtyUnit,
b.UsedAmount/b.Qty as UnitPrice,(b.UsedAmount/b.Qty)*b.CurRate as FUnitPrice,
b.UsedAmount as Amt,
b.UsedAmount/b.CurRate as FAmt,
0 as DiscountType,0 as DiscountPerc,0 as AmtDiscount,0 as FAmtDiscount,
CASE WHEN b.Tax50TaviRate>0 THEN 1 ELSE 0 END as Is50Tavi,
b.Tax50TaviRate as Rate50Tavi,
b.Tax50Tavi as Amt50Tavi,
b.VATType as IsTaxCharge,s.IsCredit,s.IsExpense,
b.ChargeVAT as AmtVat,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END) as TotalAmt,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END)/b.CurRate as FTotalAmt,
CASE WHEN s.IsCredit=1 AND s.IsExpense=0  THEN b.UsedAmount+b.ChargeVAT ELSE 0 END as AmtAdvance,
CASE WHEN s.IsCredit=0 AND s.IsExpense=0  THEN b.UsedAmount ELSE 0 END as AmtCharge,
b.CurrencyCode as CurrencyCodeCredit,b.CurRate as ExchangeRateCredit,0 as AmtCredit,0 as FAmtCredit,b.VATRate,
a.CTN_NO,c.CustCode,c.CustBranch,
b.JobNo,b.ClrNo,b.ItemNo as ClrItemNo,b.ClrNo+''/''+Convert(varchar,b.ItemNo) as ClrNoList,
(CASE WHEN s.IsExpense=1 THEN b.UsedAmount ELSE 0 END) as AmtCost,
(CASE WHEN s.IsCredit=1 THEN b.UsedAmount+b.ChargeVAT ELSE b.BNet END) as AmtNet
from Job_ClearHeader a INNER JOIN Job_ClearDetail b
ON a.BranchCode=b.BranchCode
AND a.ClrNo=b.ClrNo
INNER JOIN Job_SrvSingle s
ON b.SICode=s.SICode
INNER JOIN Job_Order c
ON b.BranchCode=c.BranchCode
and b.JobNo=c.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClrFromAdvance', N'select a.PaymentDate,a.PaymentRef,a.AdvNo,a.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
a.SICode,a.SDescription,a.CustCode,a.CustBranch,
sum(d.UsedAmount+d.ChargeVAT) as ClrTotal,
ISNULL(a.AdvNet,0)-sum(d.BNet) as ClrBal,
sum(d.UsedAmount) as ClrAmount,
SUM(d.Tax50Tavi) as Clr50Tavi,SUM(d.ChargeVAT) as ClrVat,
SUM(d.BNet) as ClrNet,a.ForJNo
from Job_ClearHeader h
left join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.PaymentRef,ah.JobType,
  ah.EmpCode,ah.AdvDate,ad.SICode,ad.SDescription,ad.AdvAmount,ad.ChargeVAT,ad.Charge50Tavi,ad.AdvNet,
  ah.CustCode,ah.CustBranch,ah.DocStatus,ad.ForJNo
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
  where ah.DocStatus<>99 
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.BranchCode,j.JNo,j.CustCode,j.CustBranch,j.InvNo,j.JobStatus,j.CloseJobDate,
  c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
{0} 
group by a.PaymentDate,a.PaymentRef,a.AdvNo,a.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
a.SICode,a.SDescription,a.CustCode,a.CustBranch,a.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClrHeader', N'select a.*,
b.CustCode,b.CustBranch,b.JobNo,b.InvNo as CustInvNo,b.CurrencyCode,b.AdvNO,b.AdvNet,
b.ClrAmt,b.BaseVat,b.RateVAT,b.ClrVat,b.Base50Tavi,b.Rate50Tavi,b.Clr50Tavi,b.ClrNet
FROM Job_ClearHeader as a 
left join 
(
    SELECT d.BranchCode,d.ClrNo,d.JobNo,j.InvNo,j.CustCode,j.CustBranch,
    d.AdvNO,d.CurrencyCode,
    SUM(d.UsedAmount) as ClrAmt,sum(d.AdvAmount) as AdvNet,
    SUM(CASE WHEN d.ChargeVAT>0 THEN d.UsedAmount ELSE 0 END) as BaseVat,
    SUM(CASE WHEN d.Tax50Tavi>0 THEN d.UsedAmount ELSE 0 END) as Base50Tavi,
    SUM(d.ChargeVAT) as ClrVat,SUM(d.Tax50Tavi) as Clr50Tavi,
    MAX(VATRate) as RateVAT,MAX(Tax50TaviRate) as Rate50Tavi,
    SUM(d.BNet) as ClrNet
    FROM Job_ClearDetail d
    inner join Job_Order j on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
    GROUP BY d.BranchCode,d.ClrNo,d.JobNo,j.InvNo,j.CustCode,j.CustBranch,
    d.AdvNO,d.CurrencyCode
) b
on b.BranchCode=a.BranchCode
and b.ClrNo=a.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectClrNoAdvance', N'select h.ClrDate,h.ReceiveRef,h.ClrNo,d.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
d.SICode,d.SDescription,j.CustCode,j.CustBranch,sum(d.UsedAmount+d.ChargeVAT) as ClrTotal,
ISNULL(a.AdvNet,0)-sum(d.BNet) as ClrBal,
sum(d.UsedAmount) as ClrAmount,
SUM(d.Tax50Tavi) as Clr50Tavi,SUM(d.ChargeVAT) as ClrVat,
SUM(d.BNet) as ClrNet,d.JobNo as ForJNo
from Job_ClearHeader h
left join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.PaymentRef,ah.JobType,
  ah.EmpCode,ah.AdvDate,ad.SICode,ad.SDescription,ad.AdvAmount,ad.ChargeVAT,ad.Charge50Tavi,ad.AdvNet,
  ah.CustCode,ah.CustBranch
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
  where ah.DocStatus <>99
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.BranchCode,j.JNo,j.CustCode,j.CustBranch,j.InvNo,j.JobStatus,j.CloseJobDate,
  c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
{0} 
group by h.ClrDate,h.ReceiveRef,h.ClrNo,d.ItemNo,a.AdvAmount,a.ChargeVAT,a.Charge50Tavi,a.AdvNet,
d.SICode,d.SDescription,j.CustCode,j.CustBranch,d.JobNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectCNDNByInvoice', N'select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectCNDNSummary', N'SELECT a.*,b.InvoiceNo,
b.TotalAmt,b.TotalVAT,b.TotalWHT,b.TotalNet,b.FTotalNet
FROM Job_CNDNHeader a LEFT JOIN
(
    SELECT BranchCode,DocNo,
    (SELECT STUFF((
SELECT DISTINCT '','' + BillingNo
FROM Job_CNDNDetail WHERE BranchCode=d.BranchCode
AND DocNo=d.DocNo  
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as InvoiceNo,
    Sum(DiffAmt) as TotalAmt,
    Sum(VATAmt) as TotalVAT,
    Sum(WHTAmt) as TotalWHT,
    Sum(TotalNet) as TotalNet,
    Sum(ForeignNet) as FTotalNet
    FROM Job_CNDNDetail d
    GROUP BY BranchCode,DocNo
) b
ON a.BranchCode=b.BranchCode
AND a.DocNo=b.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectContainerReport', N'SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocList', N'SELECT * FROM (
select Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2) as Period,''ADV'' as DocType,AdvNo as DocNo,AdvDate as DocDate 
from Job_AdvHeader where DocStatus<>99 
union
select Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2) as Period,''CLR'' as DocType,ClrNo as DocNo,ClrDate as DocDate 
from Job_ClearHeader where DocStatus<>99 
UNION
select Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2) as Period,''INV'' as DocType,DocNo,CreateDate as DocDate 
from Job_InvoiceHeader where NOT ISNULL(CancelProve,'''')<>''''
) t {0} ORDER BY t.DocType,t.Period,t.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocListCancel', N'SELECT * FROM (
select Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2) as Period,''ADV'' as DocType,AdvNo as DocNo,AdvDate as DocDate 
from Job_AdvHeader where DocStatus=99 
union
select Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2) as Period,''CLR'' as DocType,ClrNo as DocNo,ClrDate as DocDate 
from Job_ClearHeader where DocStatus=99 
UNION
select Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2) as Period,''INV'' as DocType,DocNo,CreateDate as DocDate 
from Job_InvoiceHeader where ISNULL(CancelProve,'''')<>''''
) t {0} ORDER BY t.DocType,t.Period,t.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocSummmary', N'SELECT * FROM (
select Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2) as Period,''ADV'' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus<>99 
group by Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2)
union
SELECT Convert(varchar,Year(AdvDate))+''/ALL'' as Period,''ADV'' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus<>99 
group by Convert(varchar,Year(AdvDate))
UNION
select Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2) as Period,''CLR'' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus<>99 
group by Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2)
union
SELECT Convert(varchar,Year(ClrDate))+''/ALL'' as Period,''CLR'' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus<>99 
group by Convert(varchar,Year(ClrDate))
UNION
select Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2) as Period,''INV'' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where NOT ISNULL(CancelProve,'''')<>''''
group by Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2)
union
SELECT Convert(varchar,Year(CreateDate))+''/ALL'' as Period,''INV'' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where NOT ISNULL(CancelProve,'''')<>''''
group by Convert(varchar,Year(CreateDate))
) t {0} ORDER BY t.DocType,t.Period')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocSummmaryCancel', N'SELECT * FROM (
select Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2) as Period,''ADV'' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus=99 
group by Convert(varchar,Year(AdvDate))+''/''+RIGHT(''0''+Convert(varchar,Month(AdvDate)),2)
union
SELECT Convert(varchar,Year(AdvDate))+''/ALL'' as Period,''ADV'' as DocType,Count(*) as CountDoc 
from Job_AdvHeader where DocStatus=99 
group by Convert(varchar,Year(AdvDate))
UNION
select Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2) as Period,''CLR'' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus=99 
group by Convert(varchar,Year(ClrDate))+''/''+RIGHT(''0''+Convert(varchar,Month(ClrDate)),2)
union
SELECT Convert(varchar,Year(ClrDate))+''/ALL'' as Period,''CLR'' as DocType,Count(*) as CountDoc 
from Job_ClearHeader where DocStatus=99 
group by Convert(varchar,Year(ClrDate))
UNION
select Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2) as Period,''INV'' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where ISNULL(CancelProve,'''')<>''''
group by Convert(varchar,Year(CreateDate))+''/''+RIGHT(''0''+Convert(varchar,Month(CreateDate)),2)
union
SELECT Convert(varchar,Year(CreateDate))+''/ALL'' as Period,''INV'' as DocType,Count(*) as CountDoc 
from Job_InvoiceHeader where ISNULL(CancelProve,'''')<>''''
group by Convert(varchar,Year(CreateDate))
) t {0} ORDER BY t.DocType,t.Period')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocumentBalanceP', N'SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''P'' AND (a.CashAmount+a.ChqAmount)>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocumentBalancePCredit', N'SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,a.CreditAmount-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''P'' AND a.CreditAmount>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocumentBalanceR', N'SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''R'' AND (a.CashAmount+a.ChqAmount)>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocumentBalanceRCredit', N'SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,a.CreditAmount-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''R'' AND a.CreditAmount>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectDocumentByJob', N'SELECT ISNULL(ah.PaymentDate,ah.AdvDate) as DocDate,ah.AdvNo as DocNo,''ADV'' as DocType,ad.SDescription as Expense,ad.AdvNet as Amount,cf.ConfigValue as DocStatus,ad.ItemNo
,(CASE WHEN ah.DocStatus=99 THEN 1 ELSE 0 END) as IsCancel
FROM Job_AdvHeader ah INNER JOIN Job_AdvDetail ad ON ah.BranchCode=ad.BranchCode AND ah.AdvNo=ad.AdvNo 
INNER JOIN (SELECT * FROM Mas_Config WHERE ConfigCode=''ADV_STATUS'') cf ON ah.DocStatus=Convert(int,cf.ConfigKey)
WHERE ad.BranchCode=''{0}'' AND ad.ForJNo=''{1}'' 
UNION 
SELECT ISNULL(ch.ApproveDate,ch.ClrDate) as DocDate,ch.ClrNo as DocNo,''CLR'' as DocType,cd.SDescription+ (CASE WHEN cd.SlipNO<>'''' THEN '' #''+cd.SlipNo ELSE '''' END) as Expense,
cd.BNet as Amount,cf.ConfigValue as DocStatus,cd.ItemNo
,(CASE WHEN ch.DocStatus=99 THEN 1 ELSE 0 END) as IsCancel
FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
INNER JOIN (SELECT * FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') cf ON ch.DocStatus=Convert(int,cf.ConfigKey)
WHERE cd.BranchCode=''{0}'' AND cd.JobNo=''{1}'' 
UNION
SELECT ih.DocDate,ih.DocNo,''INV'' as DocType,id.SDescription,cd.BNet as Amount,(CASE WHEN ISNULL(ih.BillAcceptNo,'''')='''' THEN ''UNBILL'' ELSE ''BILLED'' END) as DocStatus,id.ItemNo
,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 1 ELSE 0 END) as IsCancel
FROM Job_InvoiceHeader ih INNER JOIN Job_InvoiceDetail id ON ih.BranchCode=id.BranchCode AND ih.DocNo=id.DocNo
INNER JOIN Job_ClearDetail cd ON id.BranchCode=cd.BranchCode AND id.DocNo=cd.LinkBillNo AND id.ItemNo=cd.LinkItem
WHERE cd.BranchCode=''{0}'' AND cd.JobNo=''{1}'' 
UNION
select ch.ChqDate,ch.ChqNo,''CHQ'' as DocType,Convert(varchar,ch.ChqAmount) +'' ''+ ch.CurrencyCode +'' REF# ''+ch.PRVoucher+'' (''+vc.ControlNo+'')'' as Descr,ch.ChqAmount-SUM(ISNULL(cd.PaidAmount,0)) as Amount,
(CASE WHEN ISNULL(vc.PostedBy,'''')<>'''' THEN ''POSTED'' ELSE (CASE WHEN vc.CancelProve<>'''' THEN ''CANCEL'' ELSE ''ACTIVE'' END) END) as DocStatus,ch.ItemNo
,(CASE WHEN ISNULL(vc.CancelProve,'''')<>'''' THEN 1 ELSE 0 END) as IsCancel
FROM Job_CashControlSub ch INNER JOIN Job_CashControl vc ON ch.BranchCode=vc.BranchCode AND ch.ControlNo=vc.ControlNo
LEFT JOIN Job_CashControlDoc cd ON ch.BranchCode=cd.BranchCode AND ch.ControlNo=cd.ControlNo AND ch.acType=cd.acType
WHERE ch.BranchCode=''{0}'' AND ch.ForJNo=''{1}''
GROUP BY ch.ChqDate,ch.ChqNo,ch.ChqAmount,ch.PRVoucher,vc.ControlNo,vc.PostedBy,vc.CancelProve,ch.CurrencyCode,ch.ItemNo
UNION
select rh.ReceiptDate,rh.ReceiptNo,''RCV'' as DocType,rd.SDescription +'' INV#'' + rd.InvoiceNo as Descr,cd.BNet as Amount,
(CASE WHEN rh.CancelProve<>'''' THEN ''CANCEL'' ELSE (CASE WHEN ISNULL(rd.ControlNo,'''')<>'''' THEN ''RECEIVED'' ELSE ''ACTIVE'' END) END) as DocStatus,rd.ItemNo
,(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN 1 ELSE 0 END) as IsCancel
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_ClearDetail cd ON rd.InvoiceNo=cd.LinkBillNo AND rd.InvoiceItemNo=cd.LinkItem
WHERE cd.BranchCode=''{0}'' AND cd.JobNo=''{1}''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectExpenseFromClr', N'SELECT j.BranchCode, j.JNo, d.ClrNo, i.SICode, i.SDescription as TRemark, i.Qty as QtyBegin,  i.UnitCode as UnitCheck
, i.CurrencyCode, i.CurRate as CurrencyRate, i.UsedAmount as ChargeAmt, i.VATRate as VatRate, i.ChargeVAT as VatAmt, 
i.Tax50TaviRate as TaxRate, i.Tax50Tavi as TaxAmt, i.BNet as TotalAmt, i.FNet as TotalAmtF,1 as IsRequired,
s.NameThai, s.NameEng
FROM dbo.Job_ClearHeader AS d INNER JOIN
dbo.Job_ClearDetail AS i ON d.BranchCode = i.BranchCode AND d.ClrNo = i.ClrNo INNER JOIN
dbo.Job_Order AS j ON i.BranchCode = j.BranchCode AND i.JobNo = j.JNo INNER JOIN
dbo.Job_SrvSingle AS s ON i.SICode = s.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectExpenseFromQuo', N'SELECT j.BranchCode, j.JNo, j.QNo, i.SICode, i.DescriptionThai as TRemark, i.QtyBegin, i.QtyEnd, i.CalculateType, i.UnitCheck, i.CurrencyCode, i.CurrencyRate, i.ChargeAmt, i.Isvat, i.VatRate, i.VatAmt, i.IsTax, 
i.TaxRate, i.TaxAmt, i.TotalAmt, i.TotalCharge, i.UnitDiscntPerc, i.UnitDiscntAmt, i.VenderCode, i.VenderCost, i.BaseProfit, i.CommissionPerc, i.CommissionAmt, 
i.NetProfit, i.IsRequired,s.NameThai, s.NameEng
FROM dbo.Job_QuotationDetail AS d INNER JOIN
dbo.Job_Order AS j ON d.BranchCode = j.BranchCode AND d.QNo = j.QNo AND d.SeqNo = j.Revise AND d.JobType = j.JobType AND d.ShipBy = j.ShipBy INNER JOIN
dbo.Job_QuotationItem AS i ON d.BranchCode = i.BranchCode AND d.QNo = i.QNo AND d.SeqNo = i.SeqNo INNER JOIN
dbo.Job_SrvSingle AS s ON i.SICode = s.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvByReceive', N'select id.BranchCode,r.ReceiptNo,
r.ReceiptItemNo as ItemNo,r.CreditAmount,
r.TransferAmount,
r.CashAmount,r.ChequeAmount,r.ControlNo,r.VoucherNo,r.ControlItemNo,
ih.DocNo as InvoiceNo,ih.DocDate as InvoiceDate,id.ItemNo as InvoiceItemNo,
id.SICode,id.SDescription,id.VATRate,id.Rate50Tavi,
ISNULL(r.ReceivedAmt,0)-ISNULL(id.AmtCredit,0) as Amt,
ISNULL(r.ReceivedVat,0) as AmtVAT,
ISNULL(r.ReceivedWht,0) as Amt50Tavi,
ISNULL(r.ReceivedNet,0)-ISNULL(id.AmtCredit,0) as Net,
id.CurrencyCode as DCurrencyCode,id.ExchangeRate as DExchangeRate,
(ISNULL(r.ReceivedAmt,0)-ISNULL(id.AmtCredit,0))/id.ExchangeRate as FAmt,
ISNULL(r.ReceivedVat,0)/id.ExchangeRate as FAmtVAT,
ISNULL(r.ReceivedWht,0)/id.ExchangeRate as FAmt50Tavi,
(ISNULL(r.ReceivedNet,0)-ISNULL(id.AmtCredit,0))/id.ExchangeRate as FNet,
ih.CustCode,ih.CustBranch,ih.BillToCustCode,ih.BillToCustBranch,ih.RefNo,
id.Amt-id.AmtCredit As InvAmt,id.AmtVat as InvVat,id.Amt50Tavi as Inv50Tavi,id.TotalAmt-id.AmtCredit as InvTotal,
id.AmtAdvance,id.AmtCharge,id.AmtDiscount,id.AmtCredit,
ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,r.ReceiptDate,bh.DuePaymentDate
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join Job_BillAcceptHeader bh ON ih.BranchCode=bh.BranchCode AND ih.BillAcceptNo=bh.BillAcceptNo
inner join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
	rd.Amt as ReceivedAmt,
	rd.AmtVAT as ReceivedVat,
	rd.Amt50Tavi as ReceivedWht,
	rd.Net as ReceivedNet,
    rd.CreditAmount,rd.CashAmount,rd.ChequeAmount,rd.TransferAmount,
    rd.ReceiptNo,rh.ReceiptDate,
    rd.ItemNo as ReceiptItemNo,rd.ControlNo,rd.ControlItemNo,rd.VoucherNo
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	WHERE ISNULL(rh.CancelProve,'''')='''' {0}
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvDetail', N'SELECT d.ItemNo, d.SICode, d.SDescription, d.ExpSlipNO, d.SRemark, d.CurrencyCode, d.ExchangeRate, d.Qty, d.QtyUnit, d.UnitPrice, d.FUnitPrice, d.Amt, d.FAmt, 
    d.DiscountType, d.DiscountPerc, d.AmtDiscount, d.FAmtDiscount, d.Is50Tavi, d.Rate50Tavi, d.Amt50Tavi, d.IsTaxCharge, d.AmtVat, d.TotalAmt, d.FTotalAmt, 
    d.AmtAdvance, d.AmtCharge, d.CurrencyCodeCredit AS DCurrencyCode, d.ExchangeRateCredit AS DExchangeRate, d.AmtCredit, d.FAmtCredit, d.VATRate, 
    h.BranchCode, h.DocNo, h.DocDate, h.CustCode, h.CustBranch, h.BillToCustCode, h.BillToCustBranch, h.ContactName, h.EmpCode, h.PrintedBy, h.PrintedDate, 
    h.PrintedTime, h.RefNo, h.TotalAdvance, h.TotalCharge, h.TotalIsTaxCharge, h.TotalIs50Tavi, h.TotalVAT, h.Total50Tavi, h.TotalCustAdv, h.TotalNet, h.ForeignNet, 
    h.BillAcceptDate, h.BillIssueDate, h.BillAcceptNo, h.Remark1, h.Remark2, h.Remark3, h.Remark4, h.Remark5, h.Remark6, h.Remark7, h.Remark8, h.Remark9, 
    h.Remark10, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.ShippingRemark, h.SumDiscount, h.DiscountRate, h.DiscountCal, h.TotalDiscount, 
    h.CurrencyCode AS HCurrencyCode, h.ExchangeRate AS HExchangeRate, c1.TaxNumber AS CustTaxNumber, c1.NameThai AS CustNameThai, 
    c1.NameEng AS CustNameEng, c1.TAddress1 AS CustTAddress1, c1.TAddress2 AS CustTAddress2, c1.EAddress1 AS CustEAddress1, 
    c1.EAddress2 AS CustEAddress2, c2.TaxNumber AS BillTaxNumber, c2.NameThai AS BillNameThai, c2.NameEng AS BillNameEng, c2.TAddress1 AS BillTAddress1, 
    c2.TAddress2 AS BillTAddress2, c2.EAddress1 AS BillEAddress1, c2.EAddress2 AS BillEAddress2, u.TName AS IssueNameThai, u.EName AS IssueNameEng,
(SELECT STUFF((
SELECT DISTINCT '','' + JobNo
FROM Job_ClearDetail WHERE BranchCode=d.BranchCode
AND LinkBillNo=d.DocNo  AND LinkItem=d.ItemNo
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as FromJobNo,
(SELECT STUFF((
SELECT DISTINCT '','' + ClrNo + ''#'' + Convert(varchar,ItemNo)
FROM Job_ClearDetail WHERE BranchCode=d.BranchCode
AND LinkBillNo=d.DocNo  AND LinkItem=d.ItemNo
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as FromClrNo
FROM     dbo.Job_InvoiceDetail AS d INNER JOIN
    dbo.Job_InvoiceHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Company AS c1 ON h.CustCode = c1.CustCode AND h.CustBranch = c1.Branch INNER JOIN
    dbo.Mas_Company AS c2 ON h.BillToCustCode = c2.CustCode AND h.BillToCustBranch = c2.Branch INNER JOIN
    dbo.Mas_User AS u ON h.EmpCode = u.UserID')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvForBilling', N'SELECT a.*,
(CASE WHEN a.TotalIsTaxCharge>0 AND a.TotalCharge>a.TotalIsTaxCharge THEN a.TotalCharge-a.TotalIsTaxCharge ELSE (CASE WHEN a.TotalIsTaxCharge=0 THEN TotalCharge ELSE 0 END) END) as TotalNonVat
,b.NameThai,b.NameEng 
FROM Job_InvoiceHeader a
LEFT JOIN Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvForReceive', N'select id.BranchCode,'''' as ReceiptNo,
0 as ItemNo,0 as CreditAmount,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0)) as TransferAmount,
0 as CashAmount,0 as ChequeAmount,'''' as ControlNo,'''' as VoucherNo,0 as ControlItemNo,
ih.DocNo as InvoiceNo,ih.DocDate as InvoiceDate,id.ItemNo as InvoiceItemNo,
id.SICode,id.SDescription,id.VATRate,id.Rate50Tavi,
(id.Amt-ISNULL(id.AmtDiscount,0)-ISNULL(r.ReceivedAmt,0)-ISNULL(c.CreditAmt,0)) as Amt,
(id.AmtVat-ISNULL(r.ReceivedVat,0)-ISNULL(c.CreditVat,0)) as AmtVAT,
(id.Amt50Tavi-ISNULL(r.ReceivedWht,0)-ISNULL(c.CreditWht,0)) as Amt50Tavi,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0)) as Net,
id.CurrencyCode as DCurrencyCode,id.ExchangeRate as DExchangeRate,
(id.Amt-ISNULL(id.AmtDiscount,0)-ISNULL(r.ReceivedAmt,0)-ISNULL(c.CreditAmt,0))/id.ExchangeRate as FAmt,
(id.AmtVat-ISNULL(r.ReceivedVat,0)-ISNULL(c.CreditVat,0))/id.ExchangeRate as FAmtVAT,
(id.Amt50Tavi-ISNULL(r.ReceivedWht,0)-ISNULL(c.CreditWht,0))/id.ExchangeRate as FAmt50Tavi,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0))/id.ExchangeRate as FNet,
ih.CustCode,ih.CustBranch,ih.BillToCustCode,ih.BillToCustBranch,ih.RefNo,
id.Amt As InvAmt,id.AmtVat as InvVat,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
id.AmtAdvance,id.AmtCharge,id.AmtDiscount,id.AmtCredit,
c.CreditNo,c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,
r.LastReceiptNo,r.LastControlNo,r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet,
    max(rh.ReceiptNo) as LastReceiptNo,
    max(rd.ControlNo) as LastControlNo,
    max(rh.ReceiptDate) as ReceiptDate
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	WHERE ISNULL(rh.CancelProve,'''')='''' 
    AND ISNULL(rd.ControlNo,'''')<>'''' 
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
    select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvForReceiveAll', N'select id.BranchCode,'''' as ReceiptNo,
0 as ItemNo,0 as CreditAmount,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0)) as TransferAmount,
0 as CashAmount,0 as ChequeAmount,'''' as ControlNo,'''' as VoucherNo,0 as ControlItemNo,
ih.DocNo as InvoiceNo,ih.DocDate as InvoiceDate,id.ItemNo as InvoiceItemNo,
id.SICode,id.SDescription,id.VATRate,id.Rate50Tavi,
(id.Amt-ISNULL(id.AmtDiscount,0)-ISNULL(r.ReceivedAmt,0)-ISNULL(c.CreditAmt,0)) as Amt,
(id.AmtVat-ISNULL(r.ReceivedVat,0)-ISNULL(c.CreditVat,0)) as AmtVAT,
(id.Amt50Tavi-ISNULL(r.ReceivedWht,0)-ISNULL(c.CreditWht,0)) as Amt50Tavi,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0)) as Net,
id.CurrencyCode as DCurrencyCode,id.ExchangeRate as DExchangeRate,
(id.Amt-ISNULL(id.AmtDiscount,0)-ISNULL(r.ReceivedAmt,0)-ISNULL(c.CreditAmt,0))/id.ExchangeRate as FAmt,
(id.AmtVat-ISNULL(r.ReceivedVat,0)-ISNULL(c.CreditVat,0))/id.ExchangeRate as FAmtVAT,
(id.Amt50Tavi-ISNULL(r.ReceivedWht,0)-ISNULL(c.CreditWht,0))/id.ExchangeRate as FAmt50Tavi,
(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0))/id.ExchangeRate as FNet,
ih.CustCode,ih.CustBranch,ih.BillToCustCode,ih.BillToCustBranch,ih.RefNo,
id.Amt As InvAmt,id.AmtVat as InvVat,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
id.AmtAdvance,id.AmtCharge,id.AmtDiscount,id.AmtCredit,
c.CreditNo,c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,
r.LastReceiptNo,r.LastControlNo,r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet,
    max(rh.ReceiptNo) as LastReceiptNo,
    max(rd.ControlNo) as LastControlNo,
    max(rh.ReceiptDate) as ReceiptDate
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	WHERE ISNULL(rh.CancelProve,'''')='''' 
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
    select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvReport', N'select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
    id.Amt,id.AmtDiscount,id.AmtCredit,
    id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
    id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
    r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
    r.ReceiptNo,
    c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
    c.CreditNo,r.LastVoucher,
    r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
    v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
    c1.NameThai as CustTName,c2.NameThai as BillTName,
    c1.NameEng as CustEName,c2.NameEng as BillEName
    from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
    on id.BranchCode=ih.BranchCode
    and id.DocNo=ih.DocNo
    left join (
        select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
        max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
        max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Net ELSE 0 END) as ReceivedNet
        from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
        on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
        and ISNULL(rh.CancelProve,'''')=''''
        group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
    ) r
    on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
    left join (
        select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
        sum(cd.DiffAmt) as CreditAmt,
        sum(cd.VATAmt) as CreditVat,
        sum(cd.WHTAmt) as CreditWht,
        sum(cd.TotalNet) as CreditNet,
        max(cd.DocNo) as CreditNo
        from Job_CNDNDetail cd inner join Job_CNDNHeader ch
        on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
        and ch.DocStatus=1
        group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
    ) c
    on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
    left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
    left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
    left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
    where ISNULL(ih.CancelProve,'''')='''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectInvSummary', N'SELECT h.BranchCode,h.DocNo,h.Docdate,h.CustCode,h.CustBranch,h.CustTName,h.CustEName,
h.BillToCustCode,h.BillToCustBranch,h.BillTName,h.BillEName,h.ContactName,h.EmpCode,
h.RefNo,h.VATRate,h.TotalAdvance,h.TotalCharge,h.TotalIsTaxCharge,h.TotalIs50Tavi,
h.TotalVAT,h.Total50Tavi,h.TotalCustAdv,h.TotalNet,h.CurrencyCode,h.ExchangeRate,
h.ForeignNet,h.BillAcceptDate,h.BillIssueDate,h.BillAcceptNo,
h.Remark1,h.Remark2,h.Remark3,h.Remark4,h.Remark5,h.Remark6,h.Remark7,h.Remark8,h.Remark9,h.Remark10,
h.CancelReson,h.CancelProve,h.CancelDate,h.CancelTime,h.ShippingRemark,h.SumDiscount,
h.DiscountRate,h.DiscountCal,h.TotalDiscount
,sum(h.TotalNet) as TotalInv,sum(ISNULL(h.ReceivedNet,0)) as TotalReceive
,sum(ISNULL(h.CreditNet,0)) as TotalCredit
,sum(h.TotalNet-ISNULL(h.ReceivedNet,0)-ISNULL(h.CreditNet,0)) as TotalBalance
,max(h.ControlLink) as ControlLink
FROM (
    select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
    id.Amt,id.AmtDiscount,id.AmtCredit,
    id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
    id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
    r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
    r.ReceiptNo,
    c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
    c.CreditNo,r.LastVoucher,
    r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
    v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
    c1.NameThai as CustTName,c2.NameThai as BillTName,
    c1.NameEng as CustEName,c2.NameEng as BillEName
    from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
    on id.BranchCode=ih.BranchCode
    and id.DocNo=ih.DocNo
    left join (
        select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
        max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
        max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
        sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Net ELSE 0 END) as ReceivedNet
        from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
        on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
        and ISNULL(rh.CancelProve,'''')=''''
        group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
    ) r
    on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
    left join (
        select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
        sum(cd.DiffAmt) as CreditAmt,
        sum(cd.VATAmt) as CreditVat,
        sum(cd.WHTAmt) as CreditWht,
        sum(cd.TotalNet) as CreditNet,
        max(cd.DocNo) as CreditNo
        from Job_CNDNDetail cd inner join Job_CNDNHeader ch
        on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
        and ch.DocStatus=1
        group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
    ) c
    on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
    left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
    left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
    left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
    where ISNULL(ih.CancelProve,'''')='''' {0}
) as h
GROUP BY h.BranchCode,h.DocNo,h.Docdate,h.CustCode,h.CustBranch,h.CustTName,h.CustEName,
h.BillToCustCode,h.BillToCustBranch,h.BillTName,h.BillEName,h.ContactName,h.EmpCode,
h.RefNo,h.VATRate,h.TotalAdvance,h.TotalCharge,h.TotalIsTaxCharge,h.TotalIs50Tavi,
h.TotalVAT,h.Total50Tavi,h.TotalCustAdv,h.TotalNet,h.CurrencyCode,h.ExchangeRate,
h.ForeignNet,h.BillAcceptDate,h.BillIssueDate,h.BillAcceptNo,
h.Remark1,h.Remark2,h.Remark3,h.Remark4,h.Remark5,h.Remark6,h.Remark7,h.Remark8,h.Remark9,h.Remark10,
h.CancelReson,h.CancelProve,h.CancelDate,h.CancelTime,h.ShippingRemark,h.SumDiscount,
h.DiscountRate,h.DiscountCal,h.TotalDiscount')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectJobList', N'SELECT * FROM 
(SELECT jt.ConfigKey AS JobTypeCode, jt.ConfigValue AS JobTypeName, sb.ConfigKey AS ShipByCode, sb.ConfigValue AS ShipByName, JNo AS JobNo, 
                         Convert(varchar,Year(j.CreateDate)) + ''/'' + RIGHT(''0''+Convert(varchar,Month(j.CreateDate)),2) AS Period,Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Mas_Config AS jt INNER JOIN
                         dbo.Job_Order AS j ON CONVERT(int, jt.ConfigKey) = j.JobType INNER JOIN
                         dbo.Mas_Config AS sb ON CONVERT(int, sb.ConfigKey) = j.ShipBy
WHERE (jt.ConfigCode = N''JOB_TYPE'') AND (sb.ConfigCode = N''SHIP_BY'') AND (j.JobStatus " & If(bCancel = True, "=", "<>") & " 99) {0}
) t')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectJobReport', N'select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from {0}.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectJobSummary', N'SELECT * FROM 
(SELECT jt.ConfigKey AS JobTypeCode, jt.ConfigValue AS JobTypeName, sb.ConfigKey AS ShipByCode, sb.ConfigValue AS ShipByName, COUNT(j.JNo) AS TotalJob, 
                         Convert(varchar,Year(j.CreateDate)) + ''/'' + RIGHT(''0''+Convert(varchar,Month(j.CreateDate)),2) AS Period,Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Mas_Config AS jt INNER JOIN
                         dbo.Job_Order AS j ON CONVERT(int, jt.ConfigKey) = j.JobType INNER JOIN
                         dbo.Mas_Config AS sb ON CONVERT(int, sb.ConfigKey) = j.ShipBy
WHERE (jt.ConfigCode = N''JOB_TYPE'') AND (sb.ConfigCode = N''SHIP_BY'') AND (j.JobStatus<>99) {0}
GROUP BY jt.ConfigKey, jt.ConfigValue, sb.ConfigKey, sb.ConfigValue, Year(j.CreateDate),
Month(j.CreateDate)
UNION
SELECT ''ALL'',''**ALL TYPE**'',''ALL'',''**ALL TYPE**'',COUNT(*),Convert(varchar,Year(j.CreateDate)) +''/ALL'',Year(j.CreateDate) as FiscalYear,0 as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus<>99 {0}
GROUP BY Year(j.CreateDate)
UNION
SELECT ''ALL'',''**ALL TYPE**'',''ALL'',''**ALL TYPE**'',COUNT(*),Convert(varchar,Year(j.CreateDate)) +''/'' + RIGHT(''0''+Convert(varchar,Month(j.CreateDate)),2),Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus<>99 {0}
GROUP BY Year(j.CreateDate),Month(j.CreateDate)
) t')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectJobSummaryCancel', N'SELECT * FROM 
(SELECT jt.ConfigKey AS JobTypeCode, jt.ConfigValue AS JobTypeName, sb.ConfigKey AS ShipByCode, sb.ConfigValue AS ShipByName, COUNT(j.JNo) AS TotalJob, 
                         Convert(varchar,Year(j.CreateDate)) + ''/'' + RIGHT(''0''+Convert(varchar,Month(j.CreateDate)),2) AS Period,Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Mas_Config AS jt INNER JOIN
                         dbo.Job_Order AS j ON CONVERT(int, jt.ConfigKey) = j.JobType INNER JOIN
                         dbo.Mas_Config AS sb ON CONVERT(int, sb.ConfigKey) = j.ShipBy
WHERE (jt.ConfigCode = N''JOB_TYPE'') AND (sb.ConfigCode = N''SHIP_BY'') AND (j.JobStatus=99) {0}
GROUP BY jt.ConfigKey, jt.ConfigValue, sb.ConfigKey, sb.ConfigValue, Year(j.CreateDate),
Month(j.CreateDate)
UNION
SELECT ''ALL'',''**ALL TYPE**'',''ALL'',''**ALL TYPE**'',COUNT(*),Convert(varchar,Year(j.CreateDate)) +''/ALL'',Year(j.CreateDate) as FiscalYear,0 as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus=99 {0}
GROUP BY Year(j.CreateDate)
UNION
SELECT ''ALL'',''**ALL TYPE**'',''ALL'',''**ALL TYPE**'',COUNT(*),Convert(varchar,Year(j.CreateDate)) +''/'' + RIGHT(''0''+Convert(varchar,Month(j.CreateDate)),2),Year(j.CreateDate) as FiscalYear,Month(j.CreateDate) as JobMonth
FROM dbo.Job_Order j WHERE j.JobStatus=99 {0}
GROUP BY Year(j.CreateDate),Month(j.CreateDate)
) t')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectLoginHistory', N'select b.CustID,b.CustName,a.LogAction as UserID,Max(a.LogDateTime) as LastLogin
from TWTLog a 
INNER JOIN TWTCustomer b
ON a.CustID=b.CustID+''/''
where a.ModuleName=''LOGIN_SHIPPING'' and b.CustID=''{0}''
and a.LogAction Not in(''ADMIN'',''CS'',''BOAT'',''pasit'',''test'')
group by b.CustID,b.CustName,a.LogAction')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectLoginSummary', N'SELECT tb.* FROM (
select b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+''/''+RIGHT(''0''+Convert(varchar,Month(a.LogDateTime)),2) as Period
,REPLACE(a.CustID,b.CustID+''/'','''') as UserID
,Convert(varchar,Max(a.LogDateTime),103) as LastLogin
from TWTLog a,TWTCustomer b
where b.CustID=''{0}'' AND CHARINDEX(b.CustID,a.CustID)>0
AND REPLACE(a.CustID,b.CustID+''/'','''') NOT IN(''ADMIN'',''CS'',''BOAT'',''pasit'',''test'')
group by b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+''/''+RIGHT(''0''+Convert(varchar,Month(a.LogDateTime)),2),REPLACE(a.CustID,b.CustID+''/'','''')
) tb')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectPayForCharge', N'SELECT d.BranchCode, '''' AS ClrNo, 0 AS ItemNo, 0 AS LinkItem, ''SRV'' AS STCode, p.ChargeCode AS SICode, 
 s.NameThai + '' ('' + p.Location + '')'' as SDescription, h.VenCode AS VenderCode, d.Qty, d.QtyUnit AS UnitCode, 
 h.CurrencyCode, h.ExchangeRate AS CurRate, p.ChargeAmount as UnitPrice, 
 d.Qty * p.ChargeAmount AS FPrice, 
 (d.Qty * p.ChargeAmount / h.ExchangeRate) AS BPrice, (d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*s.IsTaxCharge AS ChargeVAT, 
 (d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*s.Is50Tavi AS Tax50Tavi,'''' AS AdvNO, 0 AS AdvAmount, (d.Qty * p.ChargeAmount / h.ExchangeRate) AS UsedAmount, 0 AS IsQuoItem, '''' AS SlipNO, 
 '''' AS Remark, 0 AS IsDuplicate, 0 AS IsLtdAdv50Tavi, '''' AS Pay50TaviTo, '''' AS NO50Tavi, NULL AS Date50Tavi,
 d.DocNo + ''#0'' AS VenderBillingNo,'''' AS AirQtyStep, '''' AS StepSub, d.ForJNo AS JobNo, 0 AS AdvItemNo, '''' AS LinkBillNo, 0 AS VATType, h.VATRate, 
 h.TaxRate AS Tax50TaviRate,'''' AS QNo, (d.Qty * p.ChargeAmount / h.ExchangeRate)+((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*s.IsTaxCharge)-((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*s.Is50Tavi) AS BNet, 
 ((d.Qty * p.ChargeAmount / h.ExchangeRate)+((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.VATRate*0.01)*d.IsTaxCharge)-((d.Qty * p.ChargeAmount / h.ExchangeRate)*(h.TaxRate*0.01)*d.Is50Tavi)) * h.ExchangeRate AS FNet ,h.DocDate as VenderBillDate,
h.RefNo,h.PoNo
  FROM dbo.Job_PaymentDetail d INNER JOIN
 dbo.Job_PaymentHeader h ON d.BranchCode = h.BranchCode AND 
 d.DocNo = h.DocNo
 INNER JOIN (SELECT x.*,y.VenderCode,y.NotifyCode FROM dbo.Job_LoadInfoDetail x INNER JOIN dbo.Job_LoadInfo y ON x.BranchCode=y.BranchCode AND x.BookingNo=y.BookingNo ) b
 ON d.BranchCode=b.BranchCode
 AND d.BookingRefNo=b.BookingNo
 AND d.BookingItemNo=b.ItemNo
   INNER JOIN dbo.Job_TransportPrice p
 ON b.BranchCode=p.BranchCode
 AND b.LocationID=p.LocationID
 AND b.VenderCode=p.VenderCode
 AND b.NotifyCode=p.CustCode
 AND d.SICode=p.SICode
 LEFT JOIN dbo.Job_SrvSingle s ON p.ChargeCode=s.SICode
 WHERE ISNULL(h.ApproveBy,'''')<>'''' AND s.IsCredit=0 AND s.IsExpense=0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectPayForClear', N'SELECT d.BranchCode, '''' AS ClrNo, 0 AS ItemNo, 0 AS LinkItem, ''EXP'' AS STCode, d.SICode, 
  d.SDescription, h.VenCode AS VenderCode, d.Qty, d.QtyUnit AS UnitCode, 
  h.CurrencyCode, h.ExchangeRate AS CurRate, d.UnitPrice, 
  d.Qty * d.UnitPrice AS FPrice, 
  d.Qty * d.UnitPrice / h.ExchangeRate AS BPrice, d.AmtVAT AS ChargeVAT, 
  d.AmtWHT AS Tax50Tavi,'''' AS AdvNO, 0 AS AdvAmount, d.Amt AS UsedAmount, 0 AS IsQuoItem, '''' AS SlipNO, 
  '''' AS Remark, 0 AS IsDuplicate, 0 AS IsLtdAdv50Tavi, '''' AS Pay50TaviTo, '''' AS NO50Tavi, NULL AS Date50Tavi,
 d.DocNo + ''#'' + Convert(varchar,d.ItemNo) AS VenderBillingNo,'''' AS AirQtyStep, '''' AS StepSub, d.ForJNo AS JobNo, 0 AS AdvItemNo, '''' AS LinkBillNo, 0 AS VATType, h.VATRate, 
 h.TaxRate AS Tax50TaviRate,'''' AS QNo, d.Total AS FNet, 
 d.Total / h.ExchangeRate AS BNet ,h.DocDate as VenderBillDate,h.RefNo,h.PoNo
 FROM dbo.Job_PaymentDetail d INNER JOIN
 dbo.Job_PaymentHeader h ON d.BranchCode = h.BranchCode AND 
 d.DocNo = h.DocNo
 WHERE d.AdvItemNo=0 AND ISNULL(h.ApproveBy,'''')<>''''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectPaymentReport', N'SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch,d.ClrRefNo,d.ClrItemNo 
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectPaymentSummary', N'SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef,
d.ForJNo as JobNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch,
SUM(d.Amt- d.AmtDisc) as Amt,SUM(d.AmtVAT) as AmtVat,SUM(d.AmtWHT) as AmtTax50Tavi,SUM(d.Total) as Total,
SUM(d.FTotal) as FTotal
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
{0}
GROUP BY h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveBy ,h.ApproveDate,
h.ApproveTime, h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, h.ApproveRef,h.PaymentRef,
d.ForJNo, d.BookingRefNo, d.BookingItemNo , h.AdvRef , j.CustCode,j.CustBranch')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectQuotation', N'SELECT dbo.Job_QuotationHeader.BranchCode, dbo.Job_QuotationHeader.QNo, dbo.Job_QuotationHeader.ReferQNo, dbo.Job_QuotationHeader.CustCode, 
    dbo.Job_QuotationHeader.CustBranch, dbo.Job_QuotationHeader.BillToCustCode, dbo.Job_QuotationHeader.BillToCustBranch, 
    dbo.Job_QuotationHeader.ContactName, dbo.Job_QuotationHeader.DocDate, dbo.Job_QuotationHeader.ManagerCode, dbo.Job_QuotationHeader.DescriptionH, 
    dbo.Job_QuotationHeader.DescriptionF, dbo.Job_QuotationHeader.TRemark, dbo.Job_QuotationHeader.DocStatus, dbo.Job_QuotationHeader.ApproveBy, 
    dbo.Job_QuotationHeader.ApproveDate, dbo.Job_QuotationHeader.ApproveTime, dbo.Job_QuotationHeader.CancelBy, dbo.Job_QuotationHeader.CancelDate, 
    dbo.Job_QuotationHeader.CancelReason, dbo.Job_QuotationDetail.JobType, dbo.Job_QuotationDetail.ShipBy, dbo.Job_QuotationDetail.Description, 
    dbo.Job_QuotationDetail.SeqNo, dbo.Job_QuotationItem.ItemNo, dbo.Job_QuotationItem.IsRequired, dbo.Job_QuotationItem.NetProfit, dbo.Job_QuotationItem.CommissionAmt, 
    dbo.Job_QuotationItem.CommissionPerc, dbo.Job_QuotationItem.BaseProfit, dbo.Job_QuotationItem.VenderCost, dbo.Job_QuotationItem.VenderCode, 
    dbo.Job_QuotationItem.UnitDiscntAmt, dbo.Job_QuotationItem.UnitDiscntPerc, dbo.Job_QuotationItem.TotalCharge, dbo.Job_QuotationItem.TotalAmt, 
    dbo.Job_QuotationItem.TaxAmt, dbo.Job_QuotationItem.TaxRate, dbo.Job_QuotationItem.IsTax, dbo.Job_QuotationItem.VatAmt, dbo.Job_QuotationItem.VatRate, 
    dbo.Job_QuotationItem.Isvat, dbo.Job_QuotationItem.ChargeAmt, dbo.Job_QuotationItem.CurrencyRate, dbo.Job_QuotationItem.CurrencyCode, 
    dbo.Job_QuotationItem.UnitCheck, dbo.Job_QuotationItem.QtyEnd, dbo.Job_QuotationItem.QtyBegin, dbo.Job_QuotationItem.CalculateType, 
    dbo.Job_QuotationItem.DescriptionThai, dbo.Job_QuotationItem.SICode
FROM dbo.Job_QuotationHeader INNER JOIN
    dbo.Job_QuotationDetail ON dbo.Job_QuotationHeader.BranchCode = dbo.Job_QuotationDetail.BranchCode AND 
    dbo.Job_QuotationHeader.QNo = dbo.Job_QuotationDetail.QNo INNER JOIN
    dbo.Job_QuotationItem ON dbo.Job_QuotationDetail.BranchCode = dbo.Job_QuotationItem.BranchCode AND 
    dbo.Job_QuotationDetail.QNo = dbo.Job_QuotationItem.QNo AND dbo.Job_QuotationDetail.SeqNo = dbo.Job_QuotationItem.SeqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectReceiptReport', N'SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
c1.TProvince as CustProvince,c2.TProvince as BillProvince,c1.TPostCode as CustPostCode,c2.TPostCode as BillPostCode,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN (
select a.BranchCode,SUBSTRING(a.DocNo,0,CHARINDEX(''#'',a.DocNo)) as InvoiceNo,
SUBSTRING(a.DocNo,CHARINDEX(''#'',a.DocNo)+1,4) as InvoiceItem,
MAX(b.ChqNo) as ChqNo,MAX(b.ChqDate) as ChqDate,MAX(b.PRVoucher) as PRVoucher
from Job_CashControlDoc a inner join Job_CashControlSub b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo and a.acType=b.acType 
WHERE a.DocType=''INV''
GROUP BY a.BranchCode,SUBSTRING(a.DocNo,0,CHARINDEX(''#'',a.DocNo)),
SUBSTRING(a.DocNo,CHARINDEX(''#'',a.DocNo)+1,4)
) vd ON id.BranchCode=vd.BranchCode AND id.DocNo=vd.InvoiceNo AND id.ItemNo=vd.InvoiceItem')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectReceiptSummary', N'select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectReceiptSummaryByInv', N'SELECT ih.BranchCode,ih.DocNo,rh.ReceiptNo,rh.ReceiptDate as ReceiveDate,rh.ReceiptType,c1.UsedLanguage,ih.CurrencyCode,ih.ExchangeRate,
rh.CustCode,rh.CustBranch,rh.BillToCustCode,rh.BillToCustBranch,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.InvoiceNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
Sum(id.AmtCharge) as AmtCharge,Sum(id.AmtAdvance) as AmtAdvance,Sum(id.Amt-id.AmtDiscount) as InvAmt,
Sum(CASE WHEN id.AmtCharge >0 THEN id.AmtVat ELSE 0 END) as InvVAT,
Sum(CASE WHEN id.AmtCharge >0 THEN id.Amt50Tavi ELSE 0 END) as Inv50Tavi,
Sum(id.TotalAmt) as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=ih.BranchCode
    AND LinkBillNo=ih.DocNo 
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
Sum(rd.Amt) as Amt,Sum(rd.FAmt) as FAmt,Sum(CASE WHEN id.AmtCharge >0 THEN rd.AmtVAT ELSE 0 END) as AmtVAT,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.FAmtVAT ELSE 0 END) as FAmtVAT,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.Amt50Tavi ELSE 0 END) as Amt50Tavi,
Sum(CASE WHEN id.AmtCharge>0 THEN rd.FAmt50Tavi ELSE 0 END) as FAmt50Tavi,
Sum(rd.Net) as Net,Sum(rd.FNet) as FNet,
Max(rd.ControlNo) as ControlNo,Max(vd.ChqNo) as ChqNo,Max(vd.ChqDate) as ChqDate,Max(vd.PRVoucher) as PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
{0}
GROUP BY ih.BranchCode,ih.DocNo,rh.ReceiptNo,rh.ReceiptDate,rh.ReceiptType,c1.UsedLanguage,ih.CurrencyCode,ih.ExchangeRate,
c1.Title , c1.NameThai,c1.NameEng,c1.TAddress1,c1.TAddress2,c1.EAddress1,c1.EAddress2,c1.Phone,c1.TaxNumber,
c2.Title , c2.NameThai,c2.NameEng,c2.TAddress1,c2.TAddress2,c2.EAddress1,c2.EAddress2,c2.Phone,c2.TaxNumber,
rd.InvoiceNo,ih.DocDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,rh.CustCode,rh.CustBranch,rh.BillToCustCode,rh.BillToCustBranch,ih.RefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectRoleAll', N'SELECT a.UserID,SUBSTRING(b.ModuleID,1,CHARINDEX(''/'',b.ModuleID)-1) as ModuleCode,
SUBSTRING(b.ModuleID,CHARINDEX(''/'',b.ModuleID)+1,50) as ModuleFunc,
(CASE WHEN MAX(CASE WHEN CHARINDEX(''M'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''M'' ELSE '''' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX(''E'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''E'' ELSE '''' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX(''I'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''I'' ELSE '''' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX(''R'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''R'' ELSE '''' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX(''D'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''D'' ELSE '''' END) +
(CASE WHEN MAX(CASE WHEN CHARINDEX(''P'',b.Author)>=0 THEN 1 ELSE 0 END)=1 THEN ''P'' ELSE '''' END) 
 as Authorize
FROM Mas_UserRolePolicy b,Mas_UserRoleDetail a
WHERE a.RoleID=b.RoleID {0}
GROUP BY a.UserID,b.ModuleID')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectServiceBudget', N'SELECT a.*,b.ID,b.TRemark,b.MaxAdvance,b.MaxCost,b.MinCharge,b.MinProfit,b.Active,b.LastUpdate,b.UpdateBy
FROM Job_SrvSingle a LEFT JOIN Job_BudgetPolicy b
ON a.SICode=b.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectSumReceipt', N'SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, SUM(dbo.Job_ReceiptDetail.Net) AS SumReceipt,
dbo.Job_Order.Commission, dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo, SUM(dbo.Job_ReceiptDetail.Net) * (dbo.Job_Order.Commission * 0.01) AS TotalComm
FROM dbo.Job_ClearDetail INNER JOIN
 dbo.Job_ClearHeader ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ClearHeader.BranchCode INNER JOIN
 dbo.Job_ReceiptDetail ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ReceiptDetail.BranchCode AND 
 dbo.Job_ClearDetail.LinkItem = dbo.Job_ReceiptDetail.InvoiceItemNo AND dbo.Job_ClearDetail.LinkBillNo = dbo.Job_ReceiptDetail.InvoiceNo INNER JOIN
 dbo.Job_ReceiptHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_ReceiptHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.ReceiptNo = dbo.Job_ReceiptHeader.ReceiptNo INNER JOIN
 dbo.Job_Order ON dbo.Job_ClearDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_ClearDetail.JobNo = dbo.Job_Order.JNo INNER JOIN
 dbo.Job_InvoiceHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_InvoiceHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.InvoiceNo = dbo.Job_InvoiceHeader.DocNo
WHERE (ISNULL(dbo.Job_InvoiceHeader.CancelProve, '''') = '''') AND (ISNULL(dbo.Job_ReceiptHeader.ReceiveRef, '''') <> '''') AND (dbo.Job_ClearHeader.DocStatus <> 99)  {0}
GROUP BY dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Commission, 
 dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectTax50TaviReport', N'SELECT cd.Date50Tavi, cd.NO50Tavi, v.VenCode, v.TaxNumber AS VenTaxNumber, v.BranchCode AS VenTaxBranch, v.TName AS VenderName, c.CustCode, 
    c.TaxNumber AS CustTaxNumber, c.Branch AS CustTaxBranch, c.NameThai AS CustName, cd.SICode, cd.SDescription, cd.UsedAmount, cd.Tax50TaviRate, 
    cd.Tax50Tavi, cd.IsLtdAdv50Tavi, cd.SlipNO
FROM     dbo.Job_ClearDetail AS cd INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch INNER JOIN
    dbo.Mas_Vender AS v ON cd.VenderCode = v.VenCode
WHERE (cd.Tax50Tavi > 0) AND ch.DocStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectTracking', N'SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, dbo.Job_LoadInfo.BookingNo, 
dbo.Job_LoadInfo.LoadDate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, 
dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, 
dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, 
dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.CauseCode, 
dbo.Job_LoadInfoDetail.Comment, dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, 
dbo.Job_LoadInfoDetail.TargetYardTime, dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, 
dbo.Job_LoadInfoDetail.UnloadFinishDate, dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, 
dbo.Job_LoadInfoDetail.Location, dbo.Job_LoadInfoDetail.ReturnDate AS TruckReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, 
dbo.Job_LoadInfoDetail.ProductDesc, dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, 
dbo.Job_LoadInfoDetail.GrossWeight, dbo.Job_LoadInfoDetail.Measurement, dbo.Job_Order.DocDate, dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, 
dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, 
dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.ClearPort, 
dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, 
dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, 
dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.EstDeliverDate, 
dbo.Job_Order.EstDeliverTime, dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, 
dbo.Job_Order.TotalGW, dbo.Job_Order.GWUnit, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, dbo.Job_Order.CommPayTo, 
dbo.Job_Order.MVesselName, dbo.Job_Order.ProjectName, dbo.Job_Order.TotalNW, dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, 
dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, dbo.Job_LoadInfoDetail.DeliveryNo, dbo.Job_Order.DeliveryTo, 
dbo.Job_Order.DeliveryAddr, dbo.Job_Order.ShippingCmd, dbo.Mas_Company.NameThai, dbo.Mas_Company.NameEng, dbo.Mas_Company.TAddress1, 
dbo.Mas_Company.TAddress2, dbo.Mas_Company.EAddress1, dbo.Mas_Company.EAddress2, dbo.Mas_Company.Phone, dbo.Mas_Company.FaxNumber, 
dbo.Mas_Company.GLAccountCode, dbo.Mas_Company.BillToCustCode, dbo.Mas_Company.BillToBranch, dbo.Mas_Company.TaxNumber
FROM  dbo.Mas_Company RIGHT OUTER JOIN
dbo.Job_Order LEFT OUTER JOIN
dbo.Mas_Vender RIGHT OUTER JOIN
dbo.Job_LoadInfo RIGHT OUTER JOIN
dbo.Job_LoadInfoDetail ON dbo.Job_LoadInfo.BranchCode = dbo.Job_LoadInfoDetail.BranchCode AND 
dbo.Job_LoadInfo.BookingNo = dbo.Job_LoadInfoDetail.BookingNo
ON dbo.Mas_Vender.BranchCode = dbo.Job_LoadInfo.BranchCode ON 
dbo.Job_Order.JNo = dbo.Job_LoadInfoDetail.JNo AND dbo.Job_Order.BranchCode = dbo.Job_LoadInfoDetail.BranchCode ON 
dbo.Mas_Company.Branch = dbo.Job_Order.CustBranch AND dbo.Mas_Company.CustCode = dbo.Job_Order.CustCode
WHERE (dbo.Job_Order.JobStatus < ''90'') {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectTrackingCount', N'SELECT t.JobStatus,COUNT(DISTINCT t.JNo) AS TotalJob FROM (
    SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, dbo.Job_LoadInfo.BookingNo, 
    dbo.Job_LoadInfo.LoadDate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, 
    dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, 
    dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, 
    dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, dbo.Job_LoadInfoDetail.ItemNo, 
    dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
    dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.CauseCode, 
    dbo.Job_LoadInfoDetail.Comment, dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, 
    dbo.Job_LoadInfoDetail.TargetYardTime, dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, 
    dbo.Job_LoadInfoDetail.UnloadFinishDate, dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, 
    dbo.Job_LoadInfoDetail.Location, dbo.Job_LoadInfoDetail.ReturnDate AS TruckReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, 
    dbo.Job_LoadInfoDetail.ProductDesc, dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, 
    dbo.Job_LoadInfoDetail.GrossWeight, dbo.Job_LoadInfoDetail.Measurement, dbo.Job_Order.DocDate, dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, 
    dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
    dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, 
    dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, 
    dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.ClearPort, 
    dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, 
    dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, 
    dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.EstDeliverDate, 
    dbo.Job_Order.EstDeliverTime, dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, 
    dbo.Job_Order.TotalGW, dbo.Job_Order.GWUnit, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, dbo.Job_Order.CommPayTo, 
    dbo.Job_Order.MVesselName, dbo.Job_Order.ProjectName, dbo.Job_Order.TotalNW, dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, 
    dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, dbo.Job_LoadInfoDetail.DeliveryNo, dbo.Job_Order.DeliveryTo, 
    dbo.Job_Order.DeliveryAddr, dbo.Job_Order.ShippingCmd, dbo.Mas_Company.NameThai, dbo.Mas_Company.NameEng, dbo.Mas_Company.TAddress1, 
    dbo.Mas_Company.TAddress2, dbo.Mas_Company.EAddress1, dbo.Mas_Company.EAddress2, dbo.Mas_Company.Phone, dbo.Mas_Company.FaxNumber, 
    dbo.Mas_Company.GLAccountCode, dbo.Mas_Company.BillToCustCode, dbo.Mas_Company.BillToBranch, dbo.Mas_Company.TaxNumber
    FROM  dbo.Mas_Company RIGHT OUTER JOIN
    dbo.Job_Order LEFT OUTER JOIN
    dbo.Mas_Vender RIGHT OUTER JOIN
    dbo.Job_LoadInfo RIGHT OUTER JOIN
    dbo.Job_LoadInfoDetail ON dbo.Job_LoadInfo.BranchCode = dbo.Job_LoadInfoDetail.BranchCode AND 
    dbo.Job_LoadInfo.BookingNo = dbo.Job_LoadInfoDetail.BookingNo
    ON dbo.Mas_Vender.BranchCode = dbo.Job_LoadInfo.BranchCode ON 
    dbo.Job_Order.JNo = dbo.Job_LoadInfoDetail.JNo AND dbo.Job_Order.BranchCode = dbo.Job_LoadInfoDetail.BranchCode ON 
    dbo.Mas_Company.Branch = dbo.Job_Order.CustBranch AND dbo.Mas_Company.CustCode = dbo.Job_Order.CustCode
    WHERE (dbo.Job_Order.JobStatus < ''90'') {0}
) as t GROUP BY t.JobStatus')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectTransport', N'SELECT dbo.Job_LoadInfo.BranchCode, dbo.Job_LoadInfo.JNo, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, dbo.Job_LoadInfo.BookingNo, 
dbo.Job_LoadInfo.LoadDate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, 
dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, 
dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, 
dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.CYContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, 
dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.CauseCode, 
dbo.Job_LoadInfoDetail.Comment, dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, 
dbo.Job_LoadInfoDetail.TargetYardTime, dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, 
dbo.Job_LoadInfoDetail.UnloadFinishDate, dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.Location, dbo.Job_LoadInfoDetail.ReturnDate AS TruckReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, 
dbo.Job_LoadInfoDetail.ProductDesc, dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit,dbo.Job_LoadInfoDetail.NetWeight,dbo.Job_LoadInfoDetail.ProductPrice, 
dbo.Job_LoadInfoDetail.GrossWeight, dbo.Job_LoadInfoDetail.Measurement,
dbo.Job_LoadInfoDetail.PlaceName1,dbo.Job_LoadInfoDetail.PlaceAddress1,dbo.Job_LoadInfoDetail.PlaceContact1, 
dbo.Job_LoadInfoDetail.PlaceName2,dbo.Job_LoadInfoDetail.PlaceAddress2,dbo.Job_LoadInfoDetail.PlaceContact2,
dbo.Job_LoadInfoDetail.PlaceName3,dbo.Job_LoadInfoDetail.PlaceAddress3,dbo.Job_LoadInfoDetail.PlaceContact3,
dbo.Job_LoadInfoDetail.PlaceName4,dbo.Job_LoadInfoDetail.PlaceAddress4,dbo.Job_LoadInfoDetail.PlaceContact4,
dbo.Job_Order.DocDate, dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, 
dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, 
dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.ClearPort, 
dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, 
dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, 
dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.EstDeliverDate, 
dbo.Job_Order.EstDeliverTime, dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.ConfirmDate, dbo.Job_Order.ShippingEmp, 
dbo.Job_Order.TotalGW, dbo.Job_Order.GWUnit, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, dbo.Job_Order.CommPayTo,
dbo.Job_Order.MVesselName, dbo.Job_Order.ProjectName, dbo.Job_Order.TotalNW, dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, 
dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, dbo.Job_LoadInfoDetail.DeliveryNo, dbo.Job_Order.DeliveryTo, 
dbo.Job_Order.DeliveryAddr,dbo.Job_Order.ShippingCmd, dbo.Mas_Company.NameThai, dbo.Mas_Company.NameEng, dbo.Mas_Company.TAddress1, dbo.Mas_Company.TAddress2, 
dbo.Mas_Company.EAddress1, dbo.Mas_Company.EAddress2, dbo.Mas_Company.Phone, dbo.Mas_Company.FaxNumber, dbo.Mas_Company.GLAccountCode, 
dbo.Mas_Company.BillToCustCode, dbo.Mas_Company.BillToBranch,dbo.Mas_Company.TaxNumber,
(CASE WHEN ISNULL(dbo.Job_LoadInfoDetail.CauseCode,'''')<>'''' THEN (case when dbo.Job_LoadInfoDetail.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN dbo.Job_LoadInfoDetail.CauseCode=''3'' THEN ''Finish'' ELSE (CASE WHEN dbo.Job_LoadInfoDetail.CauseCode=''2'' THEN ''Reject'' ELSE ''Working'' END) END) END) ELSE ''Checking'' END) as TruckStatus
FROM dbo.Mas_Company RIGHT OUTER JOIN
dbo.Job_Order RIGHT OUTER JOIN
dbo.Job_LoadInfoDetail ON dbo.Job_Order.JNo = dbo.Job_LoadInfoDetail.JNo AND 
dbo.Job_Order.BranchCode = dbo.Job_LoadInfoDetail.BranchCode RIGHT OUTER JOIN
dbo.Mas_Vender RIGHT OUTER JOIN
dbo.Job_LoadInfo ON dbo.Mas_Vender.BranchCode = dbo.Job_LoadInfo.BranchCode ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo 
ON dbo.Mas_Company.Branch = dbo.Job_Order.CustBranch AND 
dbo.Mas_Company.CustCode = dbo.Job_Order.CustCode
WHERE (dbo.Job_LoadInfo.BookingNo <> '''') {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectTransportDetail', N'SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.VenderCode,c.NotifyCode,c.JNo
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'''')<>'''' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'''')='''' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectVATBuy', N'SELECT ExpenseDate,SlipNo,VenderName,TaxNumber,Branch,ExpenseAmt,ExpenseVAT,CancelReson FROM (
SELECT cd.Date50Tavi as ExpenseDate, cd.SlipNO as SlipNo, v.TName as VenderName, v.TaxNumber, v.BranchCode as Branch, v.VenCode, cd.UsedAmount as ExpenseAmt, cd.ChargeVAT as ExpenseVAT, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.PaymentDate IS NOT NULL) AND (cd.SlipNO <> '''')
UNION
SELECT h.CancelDate, ''*''+cd.SlipNO, v.TName + ''**ยกเลิก**'', v.TaxNumber, v.BranchCode, v.VenCode, 0, 0, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.CancelDate IS NOT NULL) AND (cd.SlipNO <> '''')
) AS t {0} ORDER BY ExpenseDate,SlipNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectVATSales', N'SELECT ReceiptDate,ReceiptNo,ServiceType,TaxNumber,Branch,TotalChargeVAT,TotalVAT,TotalChargeNonVAT,CancelReson FROM (
SELECT h.ReceiptDate,h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
CASE WHEN h.TotalVAT>0 THEN d.TotalVATCharge ELSE 0 END as TotalChargeVAT,
h.TotalVAT,
CASE WHEN h.TotalVAT=0 THEN d.TotalNonVAT ELSE 0 END as TotalChargeNonVAT,
h.TotalCharge+h.TotalVAT as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h inner join (
	SELECT BranchCode,ReceiptNo,
	SUM(CASE WHEN VATRate>0 THEN Amt ELSE 0 END) as TotalVATCharge,
	SUM(CASE WHEN VATRate=0 THEN Amt ELSE 0 END) as TotalNonVAT
	FROM Job_ReceiptDetail 
	GROUP BY BranchCode,ReceiptNo
) d ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>''ADV'' AND NOT ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.DocDate,h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
CASE WHEN d.VATAmt <>0 THEN d.DiffAmt ELSE 0 END as TotalChargeVAT,
d.VATAmt,
CASE WHEN d.VATAmt =0 THEN d.DiffAmt ELSE 0 END as TotalChargeNonVAT,
d.DiffAmt+d.VATAmt as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE NOT h.DocStatus<>99
UNION
SELECT h.CancelDate,''*''+h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVat,
0 as TotalChargeNonVAT,
0 as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>''ADV'' AND ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.CancelDate,''*''+h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVAT,
0 as TotalNonVAT,
0 as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.DocStatus<>99
) AS t {0} ORDER BY ReceiptDate,ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectVoucher', N'SELECT h.BranchCode,h.ControlNo,h.VoucherDate,h.TRemark,h.CustCode,h.CustBranch,h.RecUser,h.RecDate,h.RecTime,
h.PostedBy,h.PostedDate,h.PostedTime,h.CancelReson,h.CancelProve,h.CancelDate,h.CancelTime,h.PostRefNo,
d.ItemNo,d.PRVoucher,d.PRType,d.ChqNo,d.BookCode,d.BankCode,d.BankBranch,d.ChqDate,d.CashAmount,d.ChqAmount,d.CreditAmount,
d.SumAmount,d.CurrencyCode,d.ExchangeRate,d.VatInc+d.VatExc as VatAmount,d.WhtInc+d.WhtExc as WhtAmount,d.TotalAmount,
d.TotalNet,d.IsLocal,d.ChqStatus,d.TRemark as DRemark,d.PayChqTo,d.DocNo as DRefNo,d.SICode,d.RecvBank,d.RecvBranch,
d.acType,d.ForJNo,r.ItemNo as DocItemNo,r.DocType,r.DocNo,r.DocDate,r.CmpType,r.CmpCode,r.CmpBranch,r.PaidAmount as PaidTotal,r.TotalAmount as DocTotal
FROM Job_CashControl h inner join Job_CashControlSub d
on h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
left join Job_CashControlDoc r
on d.BranchCode=r.BranchCode AND d.ControlNo=r.ControlNo
AND d.acType=r.acType')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectVoucherDetail', N'SELECT * FROM (
    select d.*,h.VoucherDate,ah.CustCode as CmpCode,ah.CustBranch as CmpBranch,ad.PayChqTo as VenderName,ad.TRemark as Remark, 
    ad.ForJNo as JobNo,ah.EmpCode, ah.AdvNo as DocRefNo,ah.AdvDate as DocDate,ad.SDescription,ad.AdvAmount as Amount,ad.ChargeVAT as VAT,ad.Charge50Tavi as WHT,ad.AdvNet as PaidAmount
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_AdvHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.PaymentRef
    inner join Job_AdvDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.AdvNo=ad.AdvNo
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
    ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.ReceiveRef
    inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.ClrNo=ad.ClrNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
    where ISNULL(ad.AdvNo,'''')=''''
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
    ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_CashControlDoc dc ON d.BranchCode=dc.BranchCode AND d.Controlno=dc.ControlNo
    AND d.acType=dc.acType
    inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.ReceiveRef
    inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
    AND ah.ClrNo=ad.ClrNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
    inner join Job_AdvDetail av on dc.BranchCode=av.BranchCode AND
    dc.DocNo =av.AdvNo+''#''+cast(av.ItemNo as varchar) AND 
	ad.BranchCode=av.BranchCode AND
	ad.AdvNo+''#''+cast(ad.AdvItemNo as varchar)=av.AdvNo+''#''+cast(av.ItemNo as varchar)
    where ISNULL(ad.AdvNo,'''')<>''''
    union
    select d.*,h.VoucherDate,j.CustCode,j.CustBranch,'''',ah.TRemark,
    c.JobNo ,ah.EmpCode, ad.InvoiceNo,ah.ReceiptDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.Amt50Tavi,ad.Net
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_ReceiptDetail ad ON h.BranchCode=ad.BranchCode
    AND h.ControlNo=ad.ControlNo
    inner join Job_ReceiptHeader ah ON ad.BranchCode=ah.BranchCode
    AND ad.ReceiptNo=ah.ReceiptNo
    left join Job_ClearDetail c ON ad.BranchCode=c.BranchCode 
    AND ad.InvoiceNo=c.LinkBillNo AND ad.InvoiceItemNo=c.LinkItem
    left join Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo
    union
    select d.*,h.VoucherDate,h.CustCode,h.CustBranch,v.TName,ad.SRemark,
    ad.ForJNo,ah.EmpCode,ad.DocNo,ah.PaymentDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.AmtWHT,ad.Total
    from Job_CashControlSub d
    inner join Job_CashControl h ON d.BranchCode=h.BranchCode
    and d.ControlNo=h.ControlNo
    inner join Job_PaymentHeader ah ON h.BranchCode=ah.BranchCode
    AND h.ControlNo=ah.PaymentRef
    inner join Job_PaymentDetail ad ON ad.BranchCode=ah.BranchCode
    AND ad.DocNo=ah.DocNo
    left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.ForJNo=j.JNo
    left join Mas_Vender v ON ah.VenCode=v.VenCode
) pr {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectVoucherDoc', N'SELECT src.*,doc.JobNo,doc.EmpCode,doc.TRemark
FROM
(select *,
(CASE WHEN CHARINDEX(''#'',DocNo)>0 THEN SUBSTRING(DocNo,1,CHARINDEX(''#'',DocNo)-1) ELSE DocNo END) as LinkNo from Job_CashControlDoc
{0}
) src
left join
(
SELECT h.BranchCode,h.AdvNo as DocNo,h.AdvDate as DocDate,
(SELECT STUFF((
SELECT DISTINCT '','' + ForJNo
FROM Job_AdvDetail WHERE BranchCode=h.BranchCode
AND AdvNo=h.AdvNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as JobNo,h.EmpCode,h.TRemark
	FROM Job_AdvHeader h 
	UNION
	SELECT h.BranchCode,h.ClrNo,h.ClrDate,
(SELECT STUFF((
SELECT DISTINCT '','' + JobNo
FROM Job_ClearDetail WHERE BranchCode=h.BranchCode
AND ClrNo=h.ClrNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as JobNo,h.EmpCode,h.TRemark
	FROM Job_ClearHeader h
	UNION
	SELECT h.BranchCode,h.DocNo,h.DocDate,
(SELECT STUFF((
SELECT DISTINCT '','' + ForJNo
FROM Job_PaymentDetail WHERE BranchCode=h.BranchCode
AND DocNo=h.DocNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as JobNo,h.EmpCode,h.Remark
	FROM Job_PaymentHeader h
	UNION
	SELECT h.BranchCode,h.DocNo,h.DocDate,h.RefNo,h.EmpCode,h.ShippingRemark
	FROM Job_InvoiceHeader h
) doc on src.BranchCode=doc.BranchCode AND src.LinkNo=doc.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectWHTax', N'SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
(CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
(CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
AND d.JNo=j.JNo 
LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'SelectWHTaxSummary', N'SELECT FormTypeName,TaxLawName,TaxNumber1 as TaxNumber,Branch1 as Branch,NameThai as TaxBy,
Year(a.PayDate) as TaxYear,Month(a.PayDate)  as TaxMonth,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayAmount END) as ServiceAmount,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayTax END) as TaxService, 
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayAmount END) as TranAmount,
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayTax END) as TaxTransport
FROM
(
    SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
    d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
    j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
    (CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
    (CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
    FROM dbo.Job_WHTax h INNER JOIN dbo.Job_WHTaxDetail d
    ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
    LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
    AND d.JNo=j.JNo 
    LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
) a LEFT JOIN dbo.Mas_Company c ON a.TaxNumber1=c.TaxNumber 
{0}
GROUP BY FormTypeName,TaxLawName,TaxNumber1,Branch1,Year(a.PayDate),Month(a.PayDate),NameThai
ORDER BY FormTypeName,NameThai,Year(a.PayDate),Month(a.PayDate)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateAdvHeader', N'update b 
set b.TotalAdvance =ISNULL(a.SumAdvance,0)
,b.TotalVAT=ISNULL(a.SumVAT,0)
,b.Total50Tavi=ISNULL(a.Sum50Tavi,0)
from Job_AdvHeader b left join 
(
	select BranchCode,AdvNo,Sum(AdvNet) as SumAdvance,
	sum(ChargeVAT) as SumVAT,
	sum(Charge50Tavi) as Sum50Tavi
	from Job_AdvDetail 
	group by BranchCode,AdvNo
) a     
on b.BranchCode =a.BranchCode
and b.AdvNo=a.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateAdvStatus', N'update adv
set adv.DocStatus=src.ClrStatus
from Job_AdvHeader adv inner join
(
    select BranchCode,AdvNo,sum(ClrCount) as ClrCount,
    (CASE WHEN sum(CASE WHEN IsDuplicate=0 THEN ClrCount ELSE 0 END)=Count(*) THEN 5 ELSE 
 (CASE WHEN Sum(ClrCount) > 0 THEN 4 ELSE Max(AdvStatus) END) 
     END) as ClrStatus 
    ,sum(ClrNet) as ClrNet,Sum(AdvNet) as AdvNet
    from
    (
        select h.BranchCode,d.AdvNo,d.ItemNo,d.IsDuplicate,d.AdvAmount as AdvNet,
        (CASE WHEN d.IsDuplicate=1 THEN ISNULL(c.ClrNet,0) ELSE ISNULL(c.AdvNet,0) END) as ClrNet,
        (CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN 3 ELSE (CASE WHEN ISNULL(h.ApproveBy,'''')<>'''' THEN 2 ELSE 1 END) END) as AdvStatus,
        (CASE WHEN c.ClrNo IS NULL THEN 0 ELSE 1 END) as ClrCount
        from Job_AdvHeader h inner join Job_AdvDetail d
        on h.BranchCode=d.BranchCode
        and h.AdvNo=d.AdvNo 
        left join
        (
            select a.BranchCode,a.AdvNO,a.AdvItemNo
            ,Max(a.ClrNo) as ClrNo
            ,Sum(a.BNet) as ClrNet,Sum(a.AdvAmount) as AdvNet 
            FROM Job_ClearDetail a inner join Job_ClearHeader b
            on a.BranchCode=b.BranchCode
            and a.ClrNo=b.ClrNo
            where b.DocStatus<>99
            group by a.BranchCode,a.AdvNO,a.AdvItemNo
        ) c
        on h.BranchCode=c.BranchCode
        and h.AdvNo=c.AdvNO
        and d.ItemNo=c.AdvItemNo
        where h.DocStatus<>99
    ) clr
    group by BranchCode,AdvNo
) src
on adv.BranchCode=src.BranchCode
and adv.AdvNo=src.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateAPClearLink', N'UPDATE p SET p.ClrRefNo=c.ClrNo ,p.ClrITemNo=c.ItemNo
FROM Job_PaymentDetail p INNER JOIN (
SELECT BranchCode,ClrNo,ItemNo,VenderBillingNo
FROM Job_ClearDetail
where clrNo not in(select ClrNo from job_ClearHeader where DocStatus=99) AND VenderBillingNo<>''''
) c
ON p.BranchCode=c.BranchCode AND p.DocNo+''#''+Convert(varchar,p.ItemNo)=c.VenderBillingNo
where p.ClrRefNo='''' AND p.ClrItemNo=0 
AND p.DocNo NOT IN(SELECT DocNo fROM Job_PaymentHeader where CancelProve<>'''')')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateBillCancelToInv', N'UPDATE a
SET a.BillAcceptNo=null,a.BillIssueDate=null,a.BillAcceptDate=null
 ,a.BillToCustCode=null,a.BillToCustBranch=null
 FROM Job_InvoiceHeader a 
WHERE a.BranchCode=''{0}'' AND a.BillAcceptNo=''{1}''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateBillHeader', N'UPDATE a
SET a.TotalCustAdv=ISNULL(b.SumCustAdvance,0),
a.TotalAdvance=ISNULL(b.SumAdvance,0),
a.TotalChargeVAT=ISNULL(b.SumChargeVAT,0),
a.TotalChargeNonVAT=ISNULL(b.SumChargeNonVAT,0),
a.TotalVAT=ISNULL(b.SumVAT,0),
a.TotalWH=ISNULL(b.SumWH,0),
a.TotalDiscount=ISNULL(b.SumDiscount,0),
a.TotalNet=ISNULL(b.SumNet,0)
FROM Job_BillAcceptHeader a 
LEFT JOIN (
    SELECT BranchCode,BillAcceptNo,
    SUM(AmtCustAdvance) as SumCustAdvance,
    SUM(AmtAdvance) as SumAdvance,
    SUM(AmtChargeVAT) as SumChargeVAT,
    SUM(AmtChargeNonVAT) as SumChargeNonVAT,
    SUM(AmtVAT) as SumVAT,
    SUM(AmtWH) as SumWH,
    SUM(AmtDiscount) as SumDiscount,
    SUM(AmtTotal) as SumNet
    FROM Job_BillAcceptDetail
    GROUP BY BranchCode,BillAcceptNo
) b
ON a.BranchCode=b.BranchCode
AND a.BillAcceptNo=b.BillAcceptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateBillToInv', N'UPDATE a 
SET a.BillAcceptNo=b.BillAcceptNo,a.BillIssueDate=b.BillDate,a.BillAcceptDate=b.BillRecvDate,
 a.BillToCustCode=b.CustCode,a.BillToCustBranch=b.CustBranch,a.DueDate=b.DuePaymentDate 
 FROM Job_InvoiceHeader a INNER JOIN (SELECT h.*,d.InvNo FROM Job_BillAcceptHeader h INNER JOIN Job_BillAcceptDetail d ON h.BranchCode=d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo WHERE NOT ISNULL(h.CancelProve,'''')<>'''') b
 ON a.BranchCode=b.BranchCode AND a.DocNo=b.InvNo 
WHERE a.BranchCode=''{0}'' AND b.BillAcceptNo=''{1}''')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClearHeader', N'UPDATE a
SET a.AdvTotal=ISNULL(b.AdvTotal,0)
,a.TotalExpense=ISNULL(b.TotalNET,0)
,a.ClearTotal=ISNULL(b.AdvTotal-b.TotalNET,0)
,a.ClearVat=ISNULL(b.TotalVAT,0)
,a.ClearWht=ISNULL(b.TotalWHT,0)
,a.ClearNet=ISNULL(b.TotalNET,0)
,a.ClearBill=ISNULL(b.TotalBill,0)
,a.ClearCost=ISNULL(b.TotalCost,0)
FROM Job_ClearHeader a LEFT JOIN (
  SELECT BranchCode,ClrNo,Sum(AdvAmount) as AdvTotal,
  Sum(ChargeVAT) as TotalVAT,Sum(Tax50Tavi) as TotalWHT,Sum(BNet) as TotalNET,
  Sum(CASE WHEN BPrice >0 THEN BPrice ELSE 0 END) as TotalBill,
  Sum(CASE WHEN BPrice =0 THEN BCost ELSE 0 END) as TotalCost
  FROM Job_ClearDetail
  GROUP BY BranchCode,ClrNo
) b
ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClrReceiveFromAdvance', N'UPDATE d SET d.DocStatus=3,d.ReceiveBy=''{0}'',d.ReceiveRef=''{1}'',d.ReceiveDate=GetDate(),d.ReceiveTime=Convert(varchar(10),GetDate(),108)
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.AdvAmount>0
	LEFT JOIN Job_AdvHeader c ON a.BranchCode=c.BranchCode
	AND a.AdvNO=c.AdVNo
    WHERE ISNULL(c.DocStatus,0)<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClrStatusFromAdvance', N'UPDATE d SET d.DocStatus=3
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.AdvAmount>0
	LEFT JOIN Job_AdvHeader c ON a.BranchCode=c.BranchCode
	AND a.AdvNO=c.AdVNo 
    WHERE ISNULL(c.DocStatus,0)<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(c.DocStatus,0)=6 THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClrStatusToClear', N'UPDATE d SET d.DocStatus=3
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,
    SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as SumBill,
    COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 
    GROUP BY a.BranchCode,a.ClrNo
    HAVING COUNT(*)>SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)
    AND SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)>0
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>3 AND d.DocStatus<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClrStatusToComplete', N'UPDATE d SET d.DocStatus=4
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus,SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99 AND a.BNet>0
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING COUNT(*)=SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>4 AND d.DocStatus<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateClrStatusToInComplete', N'UPDATE d SET d.DocStatus=(CASE WHEN ISNULL(d.ReceiveRef,'''')<>'''' THEN 3 ELSE (CASE WHEN ISNULL(d.ApproveBy,'''')<>'''' THEN 2 ELSE 1 END) END)
FROM Job_ClearHeader d INNER JOIN
(
    SELECT a.BranchCode,a.ClrNo,b.DocStatus
    ,SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as SumBill
    ,COUNT(*) as CountRow
    FROM Job_ClearDetail a INNER JOIN Job_ClearHeader b
    ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
    AND b.DocStatus<>99
    GROUP BY a.BranchCode,a.ClrNo,b.DocStatus
    HAVING SUM(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)=0
) c 
ON d.BranchCode=c.BranchCode AND d.ClrNo=c.ClrNo
WHERE d.DocStatus<>99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateContainer', N'update h
SET h.TotalContainer=d.SumContainer
FROM (
	SELECT a.BranchCode,a.JNo,
	(SELECT STUFF((
	SELECT '','' + Convert(varchar,Count(*)) + ''x'' + CTN_SIZE
	FROM Job_LoadInfoDetail WHERE BranchCode=a.BranchCode
	AND BookingNo=a.BookingNo AND ISNULL(CTN_SIZE,'''')<>''''
	AND ISNULL(CauseCode,'''')<>''99''
	GROUP BY CTN_SIZE
	FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
	)) as SumContainer
	from job_loadinfo a
) d INNER JOIN job_order h
ON d.BranchCode=h.BranchCode
AND d.JNo=h.JNo
WHERE ISNULL(d.SumContainer,'''')<>''''
AND ISNULL(d.SumContainer,'''')<>h.TotalContainer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateGLHeader', N'UPDATE a
SET a.TotalDebit=ISNULL(b.SumDebit,0),
a.TotalCredit=ISNULL(b.SumCredit,0)
FROM Job_GLHeader a LEFT JOIN (
    SELECT BranchCode,GLRefNo,SUM(DebitAmt) as SumDebit,SUM(CreditAmt) as SumCredit
    FROM Job_GLDetail GROUP BY BranchCode,GLRefNo
) b
ON a.BranchCode=b.BranchCode AND a.GLRefNo=b.GLRefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateInvoiceHeader', N'update h
set h.TotalAdvance=ROUND(d.TotalAdvance,2),
h.TotalCharge=ROUND(d.TotalCharge,2),
h.TotalIsTaxCharge=ROUND(d.TotalIsTaxCharge,2),
h.TotalIs50Tavi=ROUND(d.TotalIs50Tavi,2),
h.TotalVAT=ROUND(d.TotalVAT,2),
h.Total50Tavi=ROUND(d.Total50Tavi,2),
h.SumDiscount=ROUND(d.SumDiscount,2),
h.DiscountCal=ROUND(d.TotalNet*(h.DiscountRate*0.01),2),
h.TotalNet=ROUND(d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)),2),
h.ForeignNet=ROUND((d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)))/h.ExchangeRate,2)
from Job_InvoiceHeader h
inner join (
	select BranchCode,DocNo,
	sum((CASE WHEN AmtCharge>0 THEN Amt-AmtDiscount ELSE 0 END)) as TotalCharge,
	sum((CASE WHEN AmtAdvance>0 THEN TotalAmt ELSE 0 END)) as TotalAdvance,
	sum(case when AmtVat>0 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIsTaxCharge, 
	sum(case when Amt50Tavi>0 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIs50Tavi,
	sum(case when AmtCharge>0 then AmtVat else 0 end) as TotalVAT,
	sum(case when AmtCharge>0 then Amt50Tavi else 0 end) as Total50Tavi,
    sum(AmtDiscount) as SumDiscount,
	sum(TotalAmt-AmtCredit) as TotalNet
	from Job_InvoiceDetail
	group by BranchCode,DocNo
) d
on h.BranchCode=d.BranchCode
and h.DocNo=d.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateJobStatus', N'UPDATE j
SET j.JobStatus=c.JobStatus
FROM Job_Order j INNER JOIN (
    SELECT s.BranchCode,s.JNo,MAX(s.JobStatus) as JobStatus
    FROM (
SELECT BranchCode,JNo,0 as JobStatus FROM Job_Order 
WHERE ConfirmDate IS NULL 
AND JobStatus<>99 AND NOT ISNULL(CancelReson,'''')<>''''
UNION
SELECT BranchCode,JNo,1 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND DutyDate IS NULL
AND JobStatus<>1 AND NOT ISNULL(CancelReson,'''')<>''''
UNION
SELECT BranchCode,JNo,1 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND NOT DutyDate<=Convert(datetime,''{0}'',102)
AND JobStatus<>1 AND NOT ISNULL(CancelReson,'''')<>''''
UNION
SELECT BranchCode,JNo,2 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NULL AND DutyDate<=Convert(datetime,''{0}'',102)
AND JobStatus<>2 AND NOT ISNULL(CancelReson,'''')<>'''' 
UNION
SELECT BranchCode,JNo,2 FROM Job_Order 
WHERE EXISTS(SELECT DISTINCT b.ForJNo FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b ON a.BranchCode=b.BranchCode AND a.AdvNo=b.AdvNo WHERE b.ForJNo=Job_Order.JNo AND a.DocStatus<>99)
AND JobStatus<2 AND NOT ISNULL(CancelReson,'''')<>'''' 
UNION
SELECT BranchCode,JNo,3 FROM Job_Order 
WHERE ConfirmDate IS NOT NULL AND CloseJobDate IS NOT NULL
AND JobStatus<>3 AND NOT ISNULL(CancelReson,'''')<>''''
UNION
SELECT a.BranchCode,a.JNo,4 FROM Job_Order a 
WHERE EXISTS(
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as TotalBill
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99 AND b.BNet>0
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)=0
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'''')<>''''
UNION 
SELECT a.BranchCode,a.JNo,5 FROM Job_Order a 
WHERE EXISTS(
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)>SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)
      AND SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)>0
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'''')<>''''
UNION 
SELECT a.BranchCode,a.JNo,6 FROM Job_Order a 
WHERE EXISTS (
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)=SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)
)
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'''')<>''''
UNION
SELECT a.BranchCode,a.JNo,7 FROM Job_Order a 
WHERE EXISTS
(
      SELECT b.BranchCode,b.JobNo as JNo,SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0)) as Balance
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      INNER JOIN Job_SrvSingle s ON b.SICode=s.SICode
      LEFT JOIN (
            SELECT rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,Sum(rd.Net) as TotalRcv,id.AmtCredit,id.AmtDiscount
            FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd
            ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
            INNER JOIN Job_InvoiceHeader ih
            ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo
            INNER JOIN Job_InvoiceDetail id
            ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
            WHERE ISNULL(rh.CancelProve,'''')='''' AND ISNULL(ih.CancelProve,'''')='''' 
            GROUP BY rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,id.AmtCredit,id.AmtDiscount
      ) r
      ON b.BranchCode=r.BranchCode AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
      LEFT JOIN (
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
      ) c
      ON b.BranchCode=c.BranchCode AND b.LinkBillNo=c.BillingNo AND b.LinkItem=c.BillItemNo
      WHERE h.DocStatus<>99 AND b.BranchCode=a.BranchCode AND b.JobNo=a.JNo       
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0))<=0
) AND a.ConfirmDate IS NOT NULL AND a.CloseJobDate IS NOT NULL  
AND a.JobStatus<>99 AND NOT ISNULL(a.CancelReson,'''')<>''''
UNION
SELECT BranchCode,JNo,98 as JobStatus FROM Job_Order 
WHERE ISNULL(CancelReson,'''')<>'''' AND JobStatus<>99 AND ISNULL(CancelProve,'''')=''''
UNION
SELECT BranchCode,JNo,99 as JobStatus FROM Job_Order 
WHERE ISNULL(CancelReson,'''')<>'''' AND ISNULL(CancelProve,'''')<>''''
UNION
SELECT a.BranchCode,a.JNo,7 FROM Job_Order a 
WHERE NOT EXISTS
(
      SELECT b.BranchCode,b.JobNo as JNo,SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0)) as Balance
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      INNER JOIN Job_SrvSingle s ON b.SICode=s.SICode
      LEFT JOIN (
            SELECT rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,Sum(rd.Net) as TotalRcv,id.AmtCredit,id.AmtDiscount
            FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd
            ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
            INNER JOIN Job_InvoiceHeader ih
            ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo
            INNER JOIN Job_InvoiceDetail id
            ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
            WHERE ISNULL(rh.CancelProve,'''')='''' AND ISNULL(ih.CancelProve,'''')='''' 
            GROUP BY rh.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,id.AmtCredit,id.AmtDiscount
      ) r
      ON b.BranchCode=r.BranchCode AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
      LEFT JOIN (
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo
      ) c
      ON b.BranchCode=c.BranchCode AND b.LinkBillNo=c.BillingNo AND b.LinkItem=c.BillItemNo
      WHERE h.DocStatus<>99 AND b.BranchCode=a.BranchCode AND b.JobNo=a.JNo       
      GROUP BY b.BranchCode,b.JobNo
      HAVING SUM(b.BNet-(CASE WHEN s.IsExpense=1 AND ISNULL(b.LinkBillNo,'''')<>'''' THEN b.BNet ELSE 0 END)-ISNULL(r.TotalRcv,0)-ISNULL(c.CreditNet,0)-ISNULL(r.AmtCredit,0)-ISNULL(r.AmtDiscount,0))<=0
) AND a.ConfirmDate IS NOT NULL AND a.CloseJobDate IS NOT NULL 
AND a.JobStatus=7 AND NOT ISNULL(a.CancelReson,'''')<>''''
UNION
SELECT a.BranchCode,a.JNo,6 FROM Job_Order a 
WHERE NOT EXISTS (
      SELECT b.BranchCode,b.JobNo as JNo,
      SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END) as TotalBill,
      COUNT(*) as TotalDoc
      FROM Job_ClearDetail b INNER JOIN Job_ClearHeader h
      ON b.BranchCode=h.BranchCode AND b.ClrNo=h.ClrNo
      WHERE b.BranchCode=a.BranchCode AND b.JobNo=a.JNo
      AND h.DocStatus<>99  AND b.BNet>0 
      GROUP BY b.BranchCode,b.JobNo
      HAVING COUNT(*)=SUM(CASE WHEN ISNULL(b.LinkBillNo,'''')<>'''' THEN 1 ELSE 0 END)
)
AND a.JobStatus=6 AND NOT ISNULL(a.CancelReson,'''')<>''''
    ) s
    GROUP BY s.BranchCode,s.JNo
) c
ON j.BranchCode=c.BranchCode
AND j.JNo=c.JNo 
WHERE j.JobStatus<> c.JobStatus
{1}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdatePayHeader', N'update b 
set b.TotalExpense =ISNULL(a.SumNet,0)
,b.TotalVAT=ISNULL(a.SumAmtVAT,0)
,b.TotalTax=ISNULL(a.SumAmtWHT,0)
,b.TotalDiscount=ISNULL(a.SumAmtDisc,0)
,b.TotalNet=ISNULL(a.SumTotal,0)
,b.ForeignAmt=ISNULL(a.SumFTotal,0)
from Job_PaymentHeader b left join 
(
	select BranchCode,DocNo,Sum(Amt-AmtDisc) as SumNet,
	sum(AmtVAT) as SumAmtVAT,
	sum(AmtWHT) as SumAmtWHT,
    sum(AmtDisc) as SumAmtDisc,
    sum(Total) as SumTotal,
    sum(FTotal) as SumFTotal
	from Job_PaymentDetail 
	group by BranchCode,DocNo
) a     
on b.BranchCode =a.BranchCode
and b.DocNo=a.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateServiceCode', N'UPDATE d
SET d.IsTaxCharge=h.IsTaxCharge,
d.Is50Tavi=h.Is50Tavi,
d.IsHaveSlip=h.IsHaveSlip,
d.IsCredit=h.IsCredit,
d.IsExpense=h.IsExpense,
d.IsLtdAdv50Tavi=h.IsLtdAdv50Tavi
FROM Job_SrvGroup h INNER JOIN Job_SrvSingle d
ON h.GroupCode=d.GroupCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SQL', N'UpdateWhTaxHeader', N'UPDATE h
SET h.TotalPayAmount=d.TotalAmt,
h.TotalPayTax=d.TotalTax
FROM Job_WHTax h INNER JOIN (
    SELECT BranchCode,DocNo,Sum(PayAmount) as TotalAmt,Sum(PayTax) as TotalTax
    FROM Job_WHTaxDetail 
    GROUP BY BranchCode,DocNo
) d
ON h.BranchCode=d.BranchCode
AND h.DocNo=d.DocNo')
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
