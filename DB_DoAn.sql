USE [DbBanHangP2]
GO
/****** Object:  Table [dbo].[vhAddCart]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhAddCart](
	[idAddCart] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[idProduct] [int] NULL,
	[nameProductAddCart] [nvarchar](250) NULL,
	[priceProductAddCart] [decimal](18, 0) NULL,
	[priceTotal] [decimal](18, 0) NULL,
	[imgProductAddCart] [text] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAddCart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhBanner]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhBanner](
	[idBanner] [int] IDENTITY(1,1) NOT NULL,
	[nameBanner] [nvarchar](250) NULL,
	[imgBanner] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBanner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhCategory]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhCategory](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[nameCategory] [nvarchar](250) NULL,
	[imgCategory] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhContact]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhContact](
	[idContact] [int] IDENTITY(1,1) NOT NULL,
	[nameUserContact] [nvarchar](250) NULL,
	[emailEmailContact] [nvarchar](250) NULL,
	[subjectContact] [nvarchar](100) NULL,
	[messageContact] [text] NULL,
	[idUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idContact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhProduct]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhProduct](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[nameProduct] [nvarchar](250) NULL,
	[priceProduct] [decimal](18, 0) NULL,
	[priceSaleProduct] [decimal](18, 0) NULL,
	[idCategory] [int] NULL,
	[idSystem] [int] NULL,
	[imgProduct] [text] NULL,
	[newProduct] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhSystem]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhSystem](
	[idSystem] [int] IDENTITY(1,1) NOT NULL,
	[nameSystemn] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[idSystem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vhUser]    Script Date: 29/9/2023 3:54:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vhUser](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[nameUser] [nvarchar](250) NULL,
	[accountUser] [varchar](250) NULL,
	[passwordUser] [varchar](20) NULL,
	[isBan] [bit] NULL,
	[isAdmin] [bit] NULL,
	[emailUser] [nvarchar](250) NULL,
	[addressUser] [nvarchar](250) NULL,
	[phoneUser] [nvarchar](20) NULL,
	[storyUser] [text] NULL,
	[imgUser] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[vhAddCart] ON 

INSERT [dbo].[vhAddCart] ([idAddCart], [idUser], [idProduct], [nameProductAddCart], [priceProductAddCart], [priceTotal], [imgProductAddCart], [quantity]) VALUES (14, 5, 1, N'Iphone 14 promax', CAST(1800000 AS Decimal(18, 0)), CAST(1800000 AS Decimal(18, 0)), N'iphone3.png', 1)
INSERT [dbo].[vhAddCart] ([idAddCart], [idUser], [idProduct], [nameProductAddCart], [priceProductAddCart], [priceTotal], [imgProductAddCart], [quantity]) VALUES (15, 5, 1, N'Iphone 14 promax', CAST(1800000 AS Decimal(18, 0)), CAST(1800000 AS Decimal(18, 0)), N'iphone3.png', 1)
INSERT [dbo].[vhAddCart] ([idAddCart], [idUser], [idProduct], [nameProductAddCart], [priceProductAddCart], [priceTotal], [imgProductAddCart], [quantity]) VALUES (16, 5, 1, N'Iphone 14 promax', CAST(1800000 AS Decimal(18, 0)), CAST(1800000 AS Decimal(18, 0)), N'iphone3.png', 1)
INSERT [dbo].[vhAddCart] ([idAddCart], [idUser], [idProduct], [nameProductAddCart], [priceProductAddCart], [priceTotal], [imgProductAddCart], [quantity]) VALUES (24, 2, 3, N'OPPO Find N2 Flip 5G', CAST(2300000 AS Decimal(18, 0)), CAST(2300000 AS Decimal(18, 0)), N'oppo1.jpg', 1)
INSERT [dbo].[vhAddCart] ([idAddCart], [idUser], [idProduct], [nameProductAddCart], [priceProductAddCart], [priceTotal], [imgProductAddCart], [quantity]) VALUES (26, 2, 2, N'Samsung Galaxy A33 5G', CAST(2300000 AS Decimal(18, 0)), CAST(2300000 AS Decimal(18, 0)), N'samgsung1.jpg', 1)
SET IDENTITY_INSERT [dbo].[vhAddCart] OFF
GO
SET IDENTITY_INSERT [dbo].[vhBanner] ON 

INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (1, N'banner1', N'brand1.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (2, N'banner2', N'brand2.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (3, N'banner3', N'brand3.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (4, N'banner4', N'brand4.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (5, N'banner5', N'brand5.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (6, N'banner6', N'brand6.png')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (7, N'banner-shop', N'banner-shop.jpg')
INSERT [dbo].[vhBanner] ([idBanner], [nameBanner], [imgBanner]) VALUES (8, N'banner-shop1', N'banner-shop1.jpg')
SET IDENTITY_INSERT [dbo].[vhBanner] OFF
GO
SET IDENTITY_INSERT [dbo].[vhCategory] ON 

INSERT [dbo].[vhCategory] ([idCategory], [nameCategory], [imgCategory]) VALUES (1, N'Nokia', N'brand1.png')
INSERT [dbo].[vhCategory] ([idCategory], [nameCategory], [imgCategory]) VALUES (2, N'Apple', N'brand4.png')
INSERT [dbo].[vhCategory] ([idCategory], [nameCategory], [imgCategory]) VALUES (3, N'Oppo', N'brand2.png')
INSERT [dbo].[vhCategory] ([idCategory], [nameCategory], [imgCategory]) VALUES (4, N'Samsung', N'brand3.png')
SET IDENTITY_INSERT [dbo].[vhCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[vhContact] ON 

INSERT [dbo].[vhContact] ([idContact], [nameUserContact], [emailEmailContact], [subjectContact], [messageContact], [idUser]) VALUES (1, N'hihi', N'hehehe@gmail.com', N'test', N'adasdasdasdsad', 2)
INSERT [dbo].[vhContact] ([idContact], [nameUserContact], [emailEmailContact], [subjectContact], [messageContact], [idUser]) VALUES (3, N'truyen tranh', N'gma@gmail.com', N'sdas', N'qreqwrqeerewqqqqqqrewerqrrrrrrrrrrrrqreqwerewqereeeeeeq', 2)
INSERT [dbo].[vhContact] ([idContact], [nameUserContact], [emailEmailContact], [subjectContact], [messageContact], [idUser]) VALUES (4, N'aaaaaaa', N'aaaaa@gmail.com', N'aaaaaaaaaa', N'aaaaaaaaaaaaa', 2)
SET IDENTITY_INSERT [dbo].[vhContact] OFF
GO
SET IDENTITY_INSERT [dbo].[vhProduct] ON 

INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (1, N'Iphone 14 promax', CAST(2000000 AS Decimal(18, 0)), CAST(1800000 AS Decimal(18, 0)), 2, 1, N'iphone3.png', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (2, N'Samsung Galaxy A33 5G', CAST(2500000 AS Decimal(18, 0)), CAST(2300000 AS Decimal(18, 0)), 4, 1, N'samgsung1.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (3, N'OPPO Find N2 Flip 5G', CAST(2500000 AS Decimal(18, 0)), CAST(2300000 AS Decimal(18, 0)), 3, 1, N'oppo1.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (4, N'Xiaomi Redmi Note 12 4G', CAST(1000000 AS Decimal(18, 0)), CAST(900000 AS Decimal(18, 0)), 1, 1, N'xiaomi1.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (5, N'Samsung Galaxy Z Fold5 5G', CAST(7000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), 4, 1, N'samsung2.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (6, N'Xiaomi Redmi A2 series', CAST(5000000 AS Decimal(18, 0)), CAST(5500000 AS Decimal(18, 0)), 1, 1, N'xiaomi2.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (7, N'iPhone 14 128GB | Chính hãng VN/A', CAST(6000000 AS Decimal(18, 0)), CAST(4500000 AS Decimal(18, 0)), 2, 1, N'iphone2.png', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (8, N'OPPO Find X5 Pro 5G', CAST(5999000 AS Decimal(18, 0)), CAST(4500000 AS Decimal(18, 0)), 3, 1, N'oppo2.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (9, N'Xiaomi Redmi Note 12S', CAST(6999000 AS Decimal(18, 0)), CAST(4999000 AS Decimal(18, 0)), 1, 1, N'xiaomi3.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (10, N'iPhone 12 128GB | Chính hãng VN/A', CAST(10999000 AS Decimal(18, 0)), CAST(9999000 AS Decimal(18, 0)), 2, 1, N'iphone3.png', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (11, N'OPPO Reno7 series', CAST(7999000 AS Decimal(18, 0)), CAST(5999000 AS Decimal(18, 0)), 3, 1, N'oppo3.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (12, N'Samsung Galaxy Z Flip4 5G', CAST(23999000 AS Decimal(18, 0)), CAST(15999000 AS Decimal(18, 0)), 4, 1, N'oppo3.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (13, N'OPPO A57 128GB', CAST(4999000 AS Decimal(18, 0)), CAST(3799000 AS Decimal(18, 0)), 3, 1, N'oppo4.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (14, N'Samsung Galaxy A53 5G 128GB', CAST(9990000 AS Decimal(18, 0)), CAST(7999000 AS Decimal(18, 0)), 4, 1, N'samsung4.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (15, N'iPhone 15 Pro Max 512GB | Chính hãng VN/A', CAST(40999000 AS Decimal(18, 0)), CAST(40000000 AS Decimal(18, 0)), 2, 1, N'iphone4.png', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (16, N'Xiaomi Redmi Note 12 Pro 5G', CAST(9000000 AS Decimal(18, 0)), CAST(8500000 AS Decimal(18, 0)), 1, 1, N'xiaomi4.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (17, N'Tivi 1000inch', CAST(1111123 AS Decimal(18, 0)), CAST(231321312312 AS Decimal(18, 0)), 4, 3, N'tivi1.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (18, N'tivi sieu let cang', CAST(100000000 AS Decimal(18, 0)), CAST(90000000 AS Decimal(18, 0)), 4, 3, N'tivi2.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (19, N'tivi do co', CAST(80000000 AS Decimal(18, 0)), CAST(70000000 AS Decimal(18, 0)), 4, 3, N'tivi3.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (20, N'Laptop Asus ', CAST(20000000 AS Decimal(18, 0)), CAST(19000000 AS Decimal(18, 0)), 2, 2, N'laptop2.jpg', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (21, N'Laptop Acer', CAST(30000000 AS Decimal(18, 0)), CAST(27000000 AS Decimal(18, 0)), 2, 2, N'laptop3.webp', 1)
INSERT [dbo].[vhProduct] ([idProduct], [nameProduct], [priceProduct], [priceSaleProduct], [idCategory], [idSystem], [imgProduct], [newProduct]) VALUES (22, N'Laptop Dell', CAST(25000000 AS Decimal(18, 0)), CAST(23000000 AS Decimal(18, 0)), 2, 2, N'laptop4.jpg', 1)
SET IDENTITY_INSERT [dbo].[vhProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[vhSystem] ON 

INSERT [dbo].[vhSystem] ([idSystem], [nameSystemn]) VALUES (1, N'Điện thoại')
INSERT [dbo].[vhSystem] ([idSystem], [nameSystemn]) VALUES (2, N'Máy tính')
INSERT [dbo].[vhSystem] ([idSystem], [nameSystemn]) VALUES (3, N'Tivi')
SET IDENTITY_INSERT [dbo].[vhSystem] OFF
GO
SET IDENTITY_INSERT [dbo].[vhUser] ON 

INSERT [dbo].[vhUser] ([idUser], [nameUser], [accountUser], [passwordUser], [isBan], [isAdmin], [emailUser], [addressUser], [phoneUser], [storyUser], [imgUser]) VALUES (1, N'tvh', N'tvh', N'123', 1, 1, N'hoang@gmail', N'PT', N'01234567', N'hellofdasssssssssssssssssssss', N'oppo2.jpg')
INSERT [dbo].[vhUser] ([idUser], [nameUser], [accountUser], [passwordUser], [isBan], [isAdmin], [emailUser], [addressUser], [phoneUser], [storyUser], [imgUser]) VALUES (2, N'hoang', N'hoang', N'123', 1, 1, N'hoang@gmail', N'PT', N'012345', N'helloewqeqwe', N'oppo2.jpg')
INSERT [dbo].[vhUser] ([idUser], [nameUser], [accountUser], [passwordUser], [isBan], [isAdmin], [emailUser], [addressUser], [phoneUser], [storyUser], [imgUser]) VALUES (4, N'test', N'test', N'123', 0, 0, N'hihi', N'igfs', N'134324', N'fdaaaaaaaaaaaafs', N'banner-shop.jpg')
INSERT [dbo].[vhUser] ([idUser], [nameUser], [accountUser], [passwordUser], [isBan], [isAdmin], [emailUser], [addressUser], [phoneUser], [storyUser], [imgUser]) VALUES (5, N'duong', N'duong', N'123', 0, 0, N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[vhUser] OFF
GO
