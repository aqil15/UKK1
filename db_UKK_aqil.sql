USE [master]
GO
/****** Object:  Database [db_UKK_aqil]    Script Date: 4/7/2021 11:33:49 PM ******/
CREATE DATABASE [db_UKK_aqil]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_UKK_aqil', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\db_UKK_aqil.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_UKK_aqil_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\db_UKK_aqil_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_UKK_aqil] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_UKK_aqil].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_UKK_aqil] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_UKK_aqil] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_UKK_aqil] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_UKK_aqil] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_UKK_aqil] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_UKK_aqil] SET  MULTI_USER 
GO
ALTER DATABASE [db_UKK_aqil] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_UKK_aqil] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_UKK_aqil] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_UKK_aqil] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_UKK_aqil] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_UKK_aqil]
GO
/****** Object:  Table [dbo].[history_lelang]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[history_lelang](
	[id_history] [char](10) NOT NULL,
	[id_lelang] [char](10) NULL,
	[id_barang] [char](10) NULL,
	[id_user] [char](10) NULL,
	[penawaran_harga] [int] NULL,
 CONSTRAINT [PK_history_lelang] PRIMARY KEY CLUSTERED 
(
	[id_history] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_barang]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_barang](
	[id_barang] [char](10) NOT NULL,
	[nama_barang] [varchar](50) NULL,
	[tgl] [date] NULL,
	[harga_awal] [int] NULL,
	[deskripsi] [varchar](100) NULL,
 CONSTRAINT [PK_tb_barang] PRIMARY KEY CLUSTERED 
(
	[id_barang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_lelang]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_lelang](
	[id_lelang] [char](10) NOT NULL,
	[id_barang] [char](10) NULL,
	[tgl_lelang] [date] NULL,
	[harga_akhir] [int] NULL,
	[id_user] [char](10) NULL,
	[id_petugas] [char](10) NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_tb_lelang] PRIMARY KEY CLUSTERED 
(
	[id_lelang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_level]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_level](
	[id_level] [char](1) NOT NULL,
	[hak] [varchar](50) NULL,
 CONSTRAINT [PK_tb_level] PRIMARY KEY CLUSTERED 
(
	[id_level] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_masyarakat]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_masyarakat](
	[id_user] [char](10) NOT NULL,
	[nama_lengkap] [varchar](50) NULL,
	[telp] [varchar](13) NULL,
	[alamat] [varchar](50) NULL,
 CONSTRAINT [PK_tb_masyarakat] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_petugas]    Script Date: 4/7/2021 11:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_petugas](
	[id_petugas] [char](10) NOT NULL,
	[nama_petugas] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[id_level] [char](1) NULL,
 CONSTRAINT [PK_tb_petugas] PRIMARY KEY CLUSTERED 
(
	[id_petugas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[history_lelang] ([id_history], [id_lelang], [id_barang], [id_user], [penawaran_harga]) VALUES (N'H-01      ', N'L-01      ', N'BR-01     ', N'U-001     ', 800000)
INSERT [dbo].[history_lelang] ([id_history], [id_lelang], [id_barang], [id_user], [penawaran_harga]) VALUES (N'H-02      ', N'L-02      ', N'BR-02     ', N'U-001     ', 9000000)
INSERT [dbo].[tb_barang] ([id_barang], [nama_barang], [tgl], [harga_awal], [deskripsi]) VALUES (N'BR-01     ', N'Hp Asus Zenfone Max Pro', CAST(N'2021-04-06' AS Date), 500000, N'layar sedikit lecet sisanya masih mulus box ada + charger')
INSERT [dbo].[tb_barang] ([id_barang], [nama_barang], [tgl], [harga_awal], [deskripsi]) VALUES (N'BR-02     ', N'Mouse Viper Ultimate', CAST(N'2021-04-06' AS Date), 350000, N'mulus bagus')
INSERT [dbo].[tb_barang] ([id_barang], [nama_barang], [tgl], [harga_awal], [deskripsi]) VALUES (N'BR-03     ', N'Jaket navi Ukuran XL', CAST(N'2021-04-07' AS Date), 50000, N'jaket masih bagus gak ada bolong ')
INSERT [dbo].[tb_barang] ([id_barang], [nama_barang], [tgl], [harga_awal], [deskripsi]) VALUES (N'BR-04     ', N'Laptop Acer ', CAST(N'2021-04-07' AS Date), 1000000, N'Masih berfungsi dengan baik')
INSERT [dbo].[tb_barang] ([id_barang], [nama_barang], [tgl], [harga_awal], [deskripsi]) VALUES (N'BR-05     ', N'proyektor', CAST(N'2021-04-07' AS Date), 200000, N'masih berfungsi dengan baik kabel lengkap')
INSERT [dbo].[tb_lelang] ([id_lelang], [id_barang], [tgl_lelang], [harga_akhir], [id_user], [id_petugas], [status]) VALUES (N'L-01      ', N'BR-01     ', CAST(N'2021-04-06' AS Date), 800000, N'U-001     ', N'P-01      ', N'Ditutup')
INSERT [dbo].[tb_lelang] ([id_lelang], [id_barang], [tgl_lelang], [harga_akhir], [id_user], [id_petugas], [status]) VALUES (N'L-02      ', N'BR-02     ', CAST(N'2021-04-06' AS Date), 9000000, N'U-001     ', N'P-01      ', N'Dibuka')
INSERT [dbo].[tb_lelang] ([id_lelang], [id_barang], [tgl_lelang], [harga_akhir], [id_user], [id_petugas], [status]) VALUES (N'L-03      ', N'BR-02     ', CAST(N'2021-04-07' AS Date), 4000000, N'U-003     ', N'P-01      ', N'Ditutup')
INSERT [dbo].[tb_lelang] ([id_lelang], [id_barang], [tgl_lelang], [harga_akhir], [id_user], [id_petugas], [status]) VALUES (N'L-04      ', N'BR-05     ', CAST(N'2021-04-07' AS Date), 700000, N'U-004     ', N'P-01      ', N'Ditutup')
INSERT [dbo].[tb_level] ([id_level], [hak]) VALUES (N'1', N'administrator')
INSERT [dbo].[tb_level] ([id_level], [hak]) VALUES (N'2', N'petugas')
INSERT [dbo].[tb_masyarakat] ([id_user], [nama_lengkap], [telp], [alamat]) VALUES (N'U-001     ', N'Anwar', N'081264962942', N'Jl Ring Road 1')
INSERT [dbo].[tb_masyarakat] ([id_user], [nama_lengkap], [telp], [alamat]) VALUES (N'U-002     ', N'faisal', N'08214123213', N'M Yani No 21')
INSERT [dbo].[tb_masyarakat] ([id_user], [nama_lengkap], [telp], [alamat]) VALUES (N'U-003     ', N'Caesar', N'081248293481', N'Lok Bakung ')
INSERT [dbo].[tb_masyarakat] ([id_user], [nama_lengkap], [telp], [alamat]) VALUES (N'U-004     ', N'Fariz', N'0812478262982', N'Jl Antasari')
INSERT [dbo].[tb_masyarakat] ([id_user], [nama_lengkap], [telp], [alamat]) VALUES (N'U-005     ', N'Bagoes', N'081289565398', N'Jl Rapak Indah')
INSERT [dbo].[tb_petugas] ([id_petugas], [nama_petugas], [username], [password], [id_level]) VALUES (N'P-01      ', N'Aqil Rasyid', N'admin', N'123', N'1')
INSERT [dbo].[tb_petugas] ([id_petugas], [nama_petugas], [username], [password], [id_level]) VALUES (N'P-02      ', N'Adhi', N'adhi', N'123', N'2')
ALTER TABLE [dbo].[tb_lelang]  WITH CHECK ADD  CONSTRAINT [FK_tb_lelang_tb_barang] FOREIGN KEY([id_barang])
REFERENCES [dbo].[tb_barang] ([id_barang])
GO
ALTER TABLE [dbo].[tb_lelang] CHECK CONSTRAINT [FK_tb_lelang_tb_barang]
GO
ALTER TABLE [dbo].[tb_lelang]  WITH CHECK ADD  CONSTRAINT [FK_tb_lelang_tb_masyarakat] FOREIGN KEY([id_user])
REFERENCES [dbo].[tb_masyarakat] ([id_user])
GO
ALTER TABLE [dbo].[tb_lelang] CHECK CONSTRAINT [FK_tb_lelang_tb_masyarakat]
GO
ALTER TABLE [dbo].[tb_lelang]  WITH CHECK ADD  CONSTRAINT [FK_tb_lelang_tb_petugas] FOREIGN KEY([id_petugas])
REFERENCES [dbo].[tb_petugas] ([id_petugas])
GO
ALTER TABLE [dbo].[tb_lelang] CHECK CONSTRAINT [FK_tb_lelang_tb_petugas]
GO
ALTER TABLE [dbo].[tb_petugas]  WITH CHECK ADD  CONSTRAINT [FK_tb_petugas_tb_level] FOREIGN KEY([id_level])
REFERENCES [dbo].[tb_level] ([id_level])
GO
ALTER TABLE [dbo].[tb_petugas] CHECK CONSTRAINT [FK_tb_petugas_tb_level]
GO
USE [master]
GO
ALTER DATABASE [db_UKK_aqil] SET  READ_WRITE 
GO
