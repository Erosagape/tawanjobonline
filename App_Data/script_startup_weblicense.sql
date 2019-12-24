INSERT [dbo].[TWTApp] ([AppID], [AppNameTH], [AppNameEN], [AppMainURL]) VALUES (N'JOBSHIPPING', N'�к������çҹ�Ի���', N'Shipping Management System', N'192.168.1.222')
GO
INSERT [dbo].[TWTCustomer] ([CustID], [CustName], [CustTaxID], [CustAddress], [CustContact], [CustTelFaxMobile], [BeginDate], [ExpireDate], [Active], [CustRemark], [CustMessage]) VALUES (N'TAWAN', N'���ѹ෤�����', N'-', N'-', N'-', N'-', CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'9999-12-31 00:00:00.000' AS DateTime), 1, N'�к����ͺ', N'���ʴդ�Ѻ')
INSERT [dbo].[TWTCustomer] ([CustID], [CustName], [CustTaxID], [CustAddress], [CustContact], [CustTelFaxMobile], [BeginDate], [ExpireDate], [Active], [CustRemark], [CustMessage]) VALUES (N'KWAN', N'��ѭ��� ෤����� �͹�� �͹���᷹��', N'-', N'-', N'-', N'-', CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'9999-12-31 00:00:00.000' AS DateTime), 1, N'�к����ͺ', N'���ʴդ�Ѻ')
GO
INSERT [dbo].[TWTCustomerApp] ([AppID], [CustID], [WebURL], [WebDBType], [WebTranDB], [WebMasDB], [WebTranConnect], [WebMasConnect], [Active], [SubscriptionID], [Seq], [DefaultLang]) VALUES (N'JOBSHIPPING', N'TAWAN', N'jobbeta.tawanasp.com', 0, N'job_beta', N'jobmaster', N'Data Source=.\MSSQLSERVER2016;Initial Catalog=job_beta;User id=tawantech;Password=ucrC89I55y;Persist Security Info=False', N'Data Source=.\MSSQLSERVER2016;Initial Catalog=jobmaster;User id=tawanasp;Password=ucrC89I55y;Persist Security Info=False', 1, 1, 1, N'TH')
INSERT [dbo].[TWTCustomerApp] ([AppID], [CustID], [WebURL], [WebDBType], [WebTranDB], [WebMasDB], [WebTranConnect], [WebMasConnect], [Active], [SubscriptionID], [Seq], [DefaultLang]) VALUES (N'JOBSHIPPING', N'KWAN', N'kwanchai.tawanasp.com', 0, N'job_kwan', N'jobmaster', N'Data Source=.\MSSQLSERVER2016;Initial Catalog=job_kwan;User id=kwanchai;Password=ucrC89I55y;Persist Security Info=False', N'Data Source=.\MSSQLSERVER2016;Initial Catalog=jobmaster;User id=tawanasp;Password=ucrC89I55y;Persist Security Info=False', 1, 1, 1, N'TH')

GO
SET IDENTITY_INSERT [dbo].[TWTSubscription] ON 
GO
INSERT [dbo].[TWTSubscription] ([SubScriptionID], [SubscriptionName], [SubscriptionDesc], [AppID], [Edition], [BeginDate], [ExpireDate], [LoginCount]) VALUES (0, N'���ͺ�к�����', N'����Ѻ CS/PGM', N'JOBSHIPPING', 0, CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'9999-12-31 00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[TWTSubscription] ([SubScriptionID], [SubscriptionName], [SubscriptionDesc], [AppID], [Edition], [BeginDate], [ExpireDate], [LoginCount]) VALUES (1, N'���ͺ�к�', N'����Ѻ www.tawantechonline.com', N'JOBSHIPPING', 0, CAST(N'2019-10-01 00:00:00.000' AS DateTime), CAST(N'2019-12-31 00:00:00.000' AS DateTime), 5)
GO
SET IDENTITY_INSERT [dbo].[TWTSubscription] OFF
GO
INSERT [dbo].[TWTUser] ([TWTUserID], [TWTUserPassword], [TWTUserName]) VALUES (N'tawantech', N'9t;yogm8', N'���ѹ෤')
GO
