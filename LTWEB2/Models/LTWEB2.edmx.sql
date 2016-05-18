
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2016 01:11:14
-- Generated from EDMX file: F:\OneDrive\OneDrivePersonal\OneDrive\Study\LTWEB2\LTWEB2\LTWEB2\Models\LTWEB2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LTWEB2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CTGioHang_GioHang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietGioHang] DROP CONSTRAINT [FK_CTGioHang_GioHang];
GO
IF OBJECT_ID(N'[dbo].[FK_CTGioHang_SanPham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietGioHang] DROP CONSTRAINT [FK_CTGioHang_SanPham];
GO
IF OBJECT_ID(N'[dbo].[FK_GioHang_NguoiDung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GioHang] DROP CONSTRAINT [FK_GioHang_NguoiDung];
GO
IF OBJECT_ID(N'[dbo].[FK_SanPham_Loai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [FK_SanPham_Loai];
GO
IF OBJECT_ID(N'[dbo].[FK_SanPham_NhaSanXuat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SanPham] DROP CONSTRAINT [FK_SanPham_NhaSanXuat];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ChiTietGioHang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietGioHang];
GO
IF OBJECT_ID(N'[dbo].[GioHang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GioHang];
GO
IF OBJECT_ID(N'[dbo].[Loai]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loai];
GO
IF OBJECT_ID(N'[dbo].[NguoiDung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NguoiDung];
GO
IF OBJECT_ID(N'[dbo].[NhaSanXuat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhaSanXuat];
GO
IF OBJECT_ID(N'[dbo].[SanPham]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SanPham];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChiTietGioHang'
CREATE TABLE [dbo].[ChiTietGioHang] (
    [GioHangID] int  NOT NULL,
    [SanPhamID] int  NOT NULL,
    [SoLuong] int  NULL
);
GO

-- Creating table 'GioHang'
CREATE TABLE [dbo].[GioHang] (
    [GioHangID] int IDENTITY(1,1) NOT NULL,
    [NguoiDungID] int  NULL,
    [NgayMua] datetime  NULL,
    [Gia] float  NULL
);
GO

-- Creating table 'Loai'
CREATE TABLE [dbo].[Loai] (
    [LoaiID] int IDENTITY(1,1) NOT NULL,
    [TenLoai] nvarchar(40)  NULL
);
GO

-- Creating table 'NguoiDung'
CREATE TABLE [dbo].[NguoiDung] (
    [NguoiDungID] int IDENTITY(1,1) NOT NULL,
    [TenDayDu] nvarchar(40)  NULL,
    [TenDangNhap] nvarchar(30)  NULL,
    [MatKhau] nvarchar(100)  NULL,
    [Email] nvarchar(30)  NULL,
    [SoDienThoai] int  NULL,
    [QuyenHan] int  NULL
);
GO

-- Creating table 'NhaSanXuat'
CREATE TABLE [dbo].[NhaSanXuat] (
    [NhaSanXuatID] int IDENTITY(1,1) NOT NULL,
    [TenNhaSanXuat] nvarchar(40)  NULL
);
GO

-- Creating table 'SanPham'
CREATE TABLE [dbo].[SanPham] (
    [SanPhamID] int IDENTITY(1,1) NOT NULL,
    [TenSanPham] nvarchar(50)  NOT NULL,
    [GiaBan] float  NULL,
    [SoLuotXem] int  NULL,
    [SoLuotBan] int  NULL,
    [SoLuongTon] int  NULL,
    [MoTa] nvarchar(1000)  NULL,
    [XuatXu] nvarchar(30)  NULL,
    [LoaiID] int  NULL,
    [NhaSanXuatID] int  NULL,
    [NgayTiepNhan] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GioHangID], [SanPhamID] in table 'ChiTietGioHang'
ALTER TABLE [dbo].[ChiTietGioHang]
ADD CONSTRAINT [PK_ChiTietGioHang]
    PRIMARY KEY CLUSTERED ([GioHangID], [SanPhamID] ASC);
GO

-- Creating primary key on [GioHangID] in table 'GioHang'
ALTER TABLE [dbo].[GioHang]
ADD CONSTRAINT [PK_GioHang]
    PRIMARY KEY CLUSTERED ([GioHangID] ASC);
GO

-- Creating primary key on [LoaiID] in table 'Loai'
ALTER TABLE [dbo].[Loai]
ADD CONSTRAINT [PK_Loai]
    PRIMARY KEY CLUSTERED ([LoaiID] ASC);
GO

-- Creating primary key on [NguoiDungID] in table 'NguoiDung'
ALTER TABLE [dbo].[NguoiDung]
ADD CONSTRAINT [PK_NguoiDung]
    PRIMARY KEY CLUSTERED ([NguoiDungID] ASC);
GO

-- Creating primary key on [NhaSanXuatID] in table 'NhaSanXuat'
ALTER TABLE [dbo].[NhaSanXuat]
ADD CONSTRAINT [PK_NhaSanXuat]
    PRIMARY KEY CLUSTERED ([NhaSanXuatID] ASC);
GO

-- Creating primary key on [SanPhamID] in table 'SanPham'
ALTER TABLE [dbo].[SanPham]
ADD CONSTRAINT [PK_SanPham]
    PRIMARY KEY CLUSTERED ([SanPhamID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GioHangID] in table 'ChiTietGioHang'
ALTER TABLE [dbo].[ChiTietGioHang]
ADD CONSTRAINT [FK_CTGioHang_GioHang]
    FOREIGN KEY ([GioHangID])
    REFERENCES [dbo].[GioHang]
        ([GioHangID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SanPhamID] in table 'ChiTietGioHang'
ALTER TABLE [dbo].[ChiTietGioHang]
ADD CONSTRAINT [FK_CTGioHang_SanPham]
    FOREIGN KEY ([SanPhamID])
    REFERENCES [dbo].[SanPham]
        ([SanPhamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CTGioHang_SanPham'
CREATE INDEX [IX_FK_CTGioHang_SanPham]
ON [dbo].[ChiTietGioHang]
    ([SanPhamID]);
GO

-- Creating foreign key on [NguoiDungID] in table 'GioHang'
ALTER TABLE [dbo].[GioHang]
ADD CONSTRAINT [FK_GioHang_NguoiDung]
    FOREIGN KEY ([NguoiDungID])
    REFERENCES [dbo].[NguoiDung]
        ([NguoiDungID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GioHang_NguoiDung'
CREATE INDEX [IX_FK_GioHang_NguoiDung]
ON [dbo].[GioHang]
    ([NguoiDungID]);
GO

-- Creating foreign key on [LoaiID] in table 'SanPham'
ALTER TABLE [dbo].[SanPham]
ADD CONSTRAINT [FK_SanPham_Loai]
    FOREIGN KEY ([LoaiID])
    REFERENCES [dbo].[Loai]
        ([LoaiID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SanPham_Loai'
CREATE INDEX [IX_FK_SanPham_Loai]
ON [dbo].[SanPham]
    ([LoaiID]);
GO

-- Creating foreign key on [NhaSanXuatID] in table 'SanPham'
ALTER TABLE [dbo].[SanPham]
ADD CONSTRAINT [FK_SanPham_NhaSanXuat]
    FOREIGN KEY ([NhaSanXuatID])
    REFERENCES [dbo].[NhaSanXuat]
        ([NhaSanXuatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SanPham_NhaSanXuat'
CREATE INDEX [IX_FK_SanPham_NhaSanXuat]
ON [dbo].[SanPham]
    ([NhaSanXuatID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------