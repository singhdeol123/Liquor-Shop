SET IDENTITY_INSERT [dbo].[Liquor] ON
INSERT INTO [dbo].[Liquor] ([Id], [LiquorStore_Name]) VALUES (1, N'Bottlo')
INSERT INTO [dbo].[Liquor] ([Id], [LiquorStore_Name]) VALUES (2, N'Rum')
INSERT INTO [dbo].[Liquor] ([Id], [LiquorStore_Name]) VALUES (3, N'Vodka')
SET IDENTITY_INSERT [dbo].[Liquor] OFF
SET IDENTITY_INSERT [dbo].[Seller] ON
INSERT INTO [dbo].[Seller] ([Id], [Seller_Name], [Seller_Address], [Seller_Contact]) VALUES (1, N'Rey', N'Auckland', N'023566787')
INSERT INTO [dbo].[Seller] ([Id], [Seller_Name], [Seller_Address], [Seller_Contact]) VALUES (2, N'Jay', N'Auckland', N'022456677')
INSERT INTO [dbo].[Seller] ([Id], [Seller_Name], [Seller_Address], [Seller_Contact]) VALUES (3, N'Tin', N'Auckland', N'022465789')
SET IDENTITY_INSERT [dbo].[Seller] OFF
SET IDENTITY_INSERT [dbo].[Buyer] ON
INSERT INTO [dbo].[Buyer] ([Id], [Buyer_Name], [Buyer_Address], [Buyer_Contact], [SellerID]) VALUES (1, N'Liz', N'Auckland', N'022456788', 1)
INSERT INTO [dbo].[Buyer] ([Id], [Buyer_Name], [Buyer_Address], [Buyer_Contact], [SellerID]) VALUES (2, N'Sit', N'Auckland', N'022546778', 2)
INSERT INTO [dbo].[Buyer] ([Id], [Buyer_Name], [Buyer_Address], [Buyer_Contact], [SellerID]) VALUES (3, N'Hani', N'Auckland', N'022668899', 3)
SET IDENTITY_INSERT [dbo].[Buyer] OFF
