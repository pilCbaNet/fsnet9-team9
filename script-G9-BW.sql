USE [master]
GO
/****** Object:  Database [BestWallet]    Script Date: 18/12/2022 07:09:03 ******/
CREATE DATABASE [BestWallet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BestWallet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BestWallet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BestWallet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BestWallet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BestWallet] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BestWallet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BestWallet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BestWallet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BestWallet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BestWallet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BestWallet] SET ARITHABORT OFF 
GO
ALTER DATABASE [BestWallet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BestWallet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BestWallet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BestWallet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BestWallet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BestWallet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BestWallet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BestWallet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BestWallet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BestWallet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BestWallet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BestWallet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BestWallet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BestWallet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BestWallet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BestWallet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BestWallet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BestWallet] SET RECOVERY FULL 
GO
ALTER DATABASE [BestWallet] SET  MULTI_USER 
GO
ALTER DATABASE [BestWallet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BestWallet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BestWallet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BestWallet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BestWallet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BestWallet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BestWallet', N'ON'
GO
ALTER DATABASE [BestWallet] SET QUERY_STORE = OFF
GO
USE [BestWallet]
GO
/****** Object:  Table [dbo].[Monedas]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monedas](
	[id_Moneda] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Codigo] [varchar](50) NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[id_Moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[CVU] [bigint] NOT NULL,
	[id_Usuario] [int] NOT NULL,
	[id_Moneda] [int] NOT NULL,
	[fechaAlta] [datetime] NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[fechaNac] [date] NOT NULL,
	[Teléfono] [bigint] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ResumenSaldo]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ResumenSaldo]
AS
SELECT        dbo.Usuarios.Nombre, dbo.Usuarios.Email, dbo.Cuentas.CVU, dbo.Cuentas.Saldo, dbo.Monedas.Nombre AS Moneda
FROM            dbo.Cuentas INNER JOIN
                         dbo.Monedas ON dbo.Cuentas.id_Moneda = dbo.Monedas.id_Moneda INNER JOIN
                         dbo.Usuarios ON dbo.Cuentas.id_Usuario = dbo.Usuarios.id_Usuario
GO
/****** Object:  Table [dbo].[TipoTransaccion]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTransaccion](
	[Id_TipoTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoTransaccion] [varchar](50) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTransaccion] PRIMARY KEY CLUSTERED 
(
	[Id_TipoTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 18/12/2022 07:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[Id_Transaccion] [int] IDENTITY(1,1) NOT NULL,
	[id_TipoTransaccion] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[monto] [float] NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
 CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED 
(
	[Id_Transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cuentas] ON 

INSERT [dbo].[Cuentas] ([id_Cuenta], [CVU], [id_Usuario], [id_Moneda], [fechaAlta], [fechaBaja]) VALUES (4, 11111, 4, 1, CAST(N'2022-12-14T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Cuentas] OFF
GO
SET IDENTITY_INSERT [dbo].[Monedas] ON 

INSERT [dbo].[Monedas] ([id_Moneda], [Nombre], [Codigo]) VALUES (1, N'ARS', NULL)
INSERT [dbo].[Monedas] ([id_Moneda], [Nombre], [Codigo]) VALUES (2, N'USD', NULL)
INSERT [dbo].[Monedas] ([id_Moneda], [Nombre], [Codigo]) VALUES (3, N'BTC', NULL)
SET IDENTITY_INSERT [dbo].[Monedas] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoTransaccion] ON 

INSERT [dbo].[TipoTransaccion] ([Id_TipoTransaccion], [NombreTipoTransaccion], [Codigo]) VALUES (1, N'prueba', N'PRU')
INSERT [dbo].[TipoTransaccion] ([Id_TipoTransaccion], [NombreTipoTransaccion], [Codigo]) VALUES (2, N'retiro', N'RET')
INSERT [dbo].[TipoTransaccion] ([Id_TipoTransaccion], [NombreTipoTransaccion], [Codigo]) VALUES (3, N'deposito', N'DEP')
SET IDENTITY_INSERT [dbo].[TipoTransaccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Transacciones] ON 

INSERT [dbo].[Transacciones] ([Id_Transaccion], [id_TipoTransaccion], [fecha], [monto], [Id_Cuenta]) VALUES (13, 3, CAST(N'2022-12-18T08:50:08.360' AS DateTime), 500, 4)
INSERT [dbo].[Transacciones] ([Id_Transaccion], [id_TipoTransaccion], [fecha], [monto], [Id_Cuenta]) VALUES (14, 2, CAST(N'2022-12-18T09:11:57.967' AS DateTime), 200, 4)
INSERT [dbo].[Transacciones] ([Id_Transaccion], [id_TipoTransaccion], [fecha], [monto], [Id_Cuenta]) VALUES (15, 3, CAST(N'2022-12-18T09:22:01.213' AS DateTime), 1400, 4)
SET IDENTITY_INSERT [dbo].[Transacciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id_Usuario], [Nombre], [Apellido], [DNI], [fechaNac], [Teléfono], [Email], [Password], [fechaAlta], [fechaBaja]) VALUES (1, N'Analia', N'Spicoña', 555, CAST(N'1990-10-03' AS Date), 555, N'analia_spicona@hotmail.com', N'12345', CAST(N'2022-02-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([id_Usuario], [Nombre], [Apellido], [DNI], [fechaNac], [Teléfono], [Email], [Password], [fechaAlta], [fechaBaja]) VALUES (2, N'a', N'b', 0, CAST(N'0001-01-01' AS Date), 0, N'b@gmail.com', N'1234', CAST(N'2022-12-14T00:44:55.170' AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([id_Usuario], [Nombre], [Apellido], [DNI], [fechaNac], [Teléfono], [Email], [Password], [fechaAlta], [fechaBaja]) VALUES (3, N'a', N'aa', 0, CAST(N'0001-01-01' AS Date), 0, N'ab@gmail.com', N'12345', CAST(N'2022-12-14T00:58:40.513' AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([id_Usuario], [Nombre], [Apellido], [DNI], [fechaNac], [Teléfono], [Email], [Password], [fechaAlta], [fechaBaja]) VALUES (4, N'nn', N'nn', 0, CAST(N'0001-01-01' AS Date), 0, N'nn@gmail.com', N'1234', CAST(N'2022-12-14T01:25:50.917' AS DateTime), NULL)
INSERT [dbo].[Usuarios] ([id_Usuario], [Nombre], [Apellido], [DNI], [fechaNac], [Teléfono], [Email], [Password], [fechaAlta], [fechaBaja]) VALUES (5, N'analia', N'spi', 0, CAST(N'0001-01-01' AS Date), 0, N'ana@gmail.com', N'1234', CAST(N'2022-12-14T20:57:09.450' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Cuentas] ADD  CONSTRAINT [DF_Cuentas_fechaAlta]  DEFAULT (getdate()) FOR [fechaAlta]
GO
ALTER TABLE [dbo].[Transacciones] ADD  CONSTRAINT [DF_Transacciones_fecha]  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_fechaAlta]  DEFAULT (getdate()) FOR [fechaAlta]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Monedas] FOREIGN KEY([id_Moneda])
REFERENCES [dbo].[Monedas] ([id_Moneda])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Monedas]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Usuarios] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Usuarios] ([id_Usuario])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Usuarios]
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_Cuentas] FOREIGN KEY([Id_Cuenta])
REFERENCES [dbo].[Cuentas] ([id_Cuenta])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_Cuentas]
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_TipoTransaccion] FOREIGN KEY([id_TipoTransaccion])
REFERENCES [dbo].[TipoTransaccion] ([Id_TipoTransaccion])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_TipoTransaccion]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cuentas"
            Begin Extent = 
               Top = 0
               Left = 318
               Bottom = 130
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Monedas"
            Begin Extent = 
               Top = 61
               Left = 15
               Bottom = 157
               Right = 185
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 52
               Left = 659
               Bottom = 179
               Right = 829
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ResumenSaldo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ResumenSaldo'
GO
USE [master]
GO
ALTER DATABASE [BestWallet] SET  READ_WRITE 
GO
