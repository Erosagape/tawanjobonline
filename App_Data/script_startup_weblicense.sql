INSERT [dbo].[TWTApp] ([AppID], [AppNameTH], [AppNameEN], [AppMainURL]) VALUES (N'JOBSHIPPING', N'ระบบบริหารงานชิปปิ้ง', N'Shipping Management System', N'192.168.1.222')
GO
INSERT [dbo].[TWTCustomer] ([CustID], [CustName], [CustTaxID], [CustAddress], [CustContact], [CustTelFaxMobile], [BeginDate], [ExpireDate], [Active], [CustRemark], [CustMessage]) VALUES (N'TAWAN', N'ตะวันเทคโนโลยี บจก', N'-', N'-', N'-', N'-', CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'9999-12-31 00:00:00.000' AS DateTime), 1, N'ระบบทดสอบ', N'สวัสดีครับ')
GO
INSERT [dbo].[TWTCustomerApp] ([AppID], [CustID], [WebURL], [WebDBType], [WebTranDB], [WebMasDB], [WebTranConnect], [WebMasConnect], [Active], [SubscriptionID], [Seq], [DefaultLang]) VALUES (N'JOBSHIPPING', N'TAWAN', N'localhost', 0, N'job_web', N'jobmaster', N'Data Source=.\DEVTEST;Initial Catalog=job_web;User id=sa;Password=1234;Persist Security Info=False', N'Data Source=.\DEVTEST;Initial Catalog=jobmaster;User id=sa;Password=1234;Persist Security Info=False', 1, 1, 1, N'TH')
GO
SET IDENTITY_INSERT [dbo].[TWTSubscription] ON 
GO
INSERT [dbo].[TWTSubscription] ([SubScriptionID], [SubscriptionName], [SubscriptionDesc], [AppID], [Edition], [BeginDate], [ExpireDate], [LoginCount]) VALUES (0, N'ทดสอบระบบภายใน', N'สำหรับ CS/PGM', N'JOBSHIPPING', 0, CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'9999-12-31 00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[TWTSubscription] ([SubScriptionID], [SubscriptionName], [SubscriptionDesc], [AppID], [Edition], [BeginDate], [ExpireDate], [LoginCount]) VALUES (1, N'ทดสอบระบบ', N'สำหรับ www.tawantechonline.com', N'JOBSHIPPING', 0, CAST(N'2019-10-01 00:00:00.000' AS DateTime), CAST(N'2019-12-31 00:00:00.000' AS DateTime), 5)
GO
SET IDENTITY_INSERT [dbo].[TWTSubscription] OFF
GO
INSERT [dbo].[TWTUser] ([TWTUserID], [TWTUserPassword], [TWTUserName]) VALUES (N'tawantech', N'9t;yogm8', N'ตะวันเทค')
GO
