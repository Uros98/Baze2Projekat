
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 00:45:37
-- Generated from EDMX file: C:\Users\Doktor\source\repos\Baze2\Baze2\KladionicaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BazaBP2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BarmenPice_Barmen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BarmenPice] DROP CONSTRAINT [FK_BarmenPice_Barmen];
GO
IF OBJECT_ID(N'[dbo].[FK_BarmenPice_Pice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BarmenPice] DROP CONSTRAINT [FK_BarmenPice_Pice];
GO
IF OBJECT_ID(N'[dbo].[FK_KorisnikTiket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tikets] DROP CONSTRAINT [FK_KorisnikTiket];
GO
IF OBJECT_ID(N'[dbo].[FK_KorisnikPice_Korisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KorisnikPice] DROP CONSTRAINT [FK_KorisnikPice_Korisnik];
GO
IF OBJECT_ID(N'[dbo].[FK_KorisnikPice_Pice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KorisnikPice] DROP CONSTRAINT [FK_KorisnikPice_Pice];
GO
IF OBJECT_ID(N'[dbo].[FK_OperaterTiket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tikets] DROP CONSTRAINT [FK_OperaterTiket];
GO
IF OBJECT_ID(N'[dbo].[FK_DogadjajTiket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dogadjajs] DROP CONSTRAINT [FK_DogadjajTiket];
GO
IF OBJECT_ID(N'[dbo].[FK_LokalRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_LokalRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Barmen_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Barmen] DROP CONSTRAINT [FK_Barmen_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Operater_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_Operater] DROP CONSTRAINT [FK_Operater_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dogadjajs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dogadjajs];
GO
IF OBJECT_ID(N'[dbo].[Tikets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tikets];
GO
IF OBJECT_ID(N'[dbo].[Korisniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Lokals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lokals];
GO
IF OBJECT_ID(N'[dbo].[Pices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pices];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Barmen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Barmen];
GO
IF OBJECT_ID(N'[dbo].[Radniks_Operater]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_Operater];
GO
IF OBJECT_ID(N'[dbo].[BarmenPice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BarmenPice];
GO
IF OBJECT_ID(N'[dbo].[KorisnikPice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KorisnikPice];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dogadjajs'
CREATE TABLE [dbo].[Dogadjajs] (
    [Id] int  NOT NULL,
    [dogKv] float  NOT NULL,
    [Tiket_Id] int  NULL
);
GO

-- Creating table 'Tikets'
CREATE TABLE [dbo].[Tikets] (
    [Id] int  NOT NULL,
    [tKv] float  NOT NULL,
    [tDob] float  NOT NULL,
    [KorisnikId] int  NOT NULL,
    [OperaterId] int  NOT NULL
);
GO

-- Creating table 'Korisniks'
CREATE TABLE [dbo].[Korisniks] (
    [Id] int  NOT NULL,
    [kIme] nvarchar(20)  NOT NULL,
    [kPrz] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [Id] int  NOT NULL,
    [radIme] nvarchar(20)  NOT NULL,
    [radPrz] nvarchar(20)  NOT NULL,
    [LokalId] int  NOT NULL
);
GO

-- Creating table 'Lokals'
CREATE TABLE [dbo].[Lokals] (
    [Id] int  NOT NULL,
    [lokNaz] nvarchar(20)  NOT NULL,
    [lokGr] nvarchar(20)  NOT NULL,
    [lokUl] nvarchar(20)  NOT NULL,
    [lokBr] int  NOT NULL
);
GO

-- Creating table 'Pices'
CREATE TABLE [dbo].[Pices] (
    [Id] int  NOT NULL,
    [piceNaz] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Radniks_Barmen'
CREATE TABLE [dbo].[Radniks_Barmen] (
    [barSektor] nvarchar(20)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Radniks_Operater'
CREATE TABLE [dbo].[Radniks_Operater] (
    [opRacunar] nvarchar(20)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'BarmenPice'
CREATE TABLE [dbo].[BarmenPice] (
    [Barmen_Id] int  NOT NULL,
    [Pices_Id] int  NOT NULL
);
GO

-- Creating table 'KorisnikPice'
CREATE TABLE [dbo].[KorisnikPice] (
    [Korisniks_Id] int  NOT NULL,
    [Pices_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Dogadjajs'
ALTER TABLE [dbo].[Dogadjajs]
ADD CONSTRAINT [PK_Dogadjajs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tikets'
ALTER TABLE [dbo].[Tikets]
ADD CONSTRAINT [PK_Tikets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Korisniks'
ALTER TABLE [dbo].[Korisniks]
ADD CONSTRAINT [PK_Korisniks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lokals'
ALTER TABLE [dbo].[Lokals]
ADD CONSTRAINT [PK_Lokals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pices'
ALTER TABLE [dbo].[Pices]
ADD CONSTRAINT [PK_Pices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Radniks_Barmen'
ALTER TABLE [dbo].[Radniks_Barmen]
ADD CONSTRAINT [PK_Radniks_Barmen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Radniks_Operater'
ALTER TABLE [dbo].[Radniks_Operater]
ADD CONSTRAINT [PK_Radniks_Operater]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Barmen_Id], [Pices_Id] in table 'BarmenPice'
ALTER TABLE [dbo].[BarmenPice]
ADD CONSTRAINT [PK_BarmenPice]
    PRIMARY KEY CLUSTERED ([Barmen_Id], [Pices_Id] ASC);
GO

-- Creating primary key on [Korisniks_Id], [Pices_Id] in table 'KorisnikPice'
ALTER TABLE [dbo].[KorisnikPice]
ADD CONSTRAINT [PK_KorisnikPice]
    PRIMARY KEY CLUSTERED ([Korisniks_Id], [Pices_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Barmen_Id] in table 'BarmenPice'
ALTER TABLE [dbo].[BarmenPice]
ADD CONSTRAINT [FK_BarmenPice_Barmen]
    FOREIGN KEY ([Barmen_Id])
    REFERENCES [dbo].[Radniks_Barmen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pices_Id] in table 'BarmenPice'
ALTER TABLE [dbo].[BarmenPice]
ADD CONSTRAINT [FK_BarmenPice_Pice]
    FOREIGN KEY ([Pices_Id])
    REFERENCES [dbo].[Pices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BarmenPice_Pice'
CREATE INDEX [IX_FK_BarmenPice_Pice]
ON [dbo].[BarmenPice]
    ([Pices_Id]);
GO

-- Creating foreign key on [KorisnikId] in table 'Tikets'
ALTER TABLE [dbo].[Tikets]
ADD CONSTRAINT [FK_KorisnikTiket]
    FOREIGN KEY ([KorisnikId])
    REFERENCES [dbo].[Korisniks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KorisnikTiket'
CREATE INDEX [IX_FK_KorisnikTiket]
ON [dbo].[Tikets]
    ([KorisnikId]);
GO

-- Creating foreign key on [Korisniks_Id] in table 'KorisnikPice'
ALTER TABLE [dbo].[KorisnikPice]
ADD CONSTRAINT [FK_KorisnikPice_Korisnik]
    FOREIGN KEY ([Korisniks_Id])
    REFERENCES [dbo].[Korisniks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pices_Id] in table 'KorisnikPice'
ALTER TABLE [dbo].[KorisnikPice]
ADD CONSTRAINT [FK_KorisnikPice_Pice]
    FOREIGN KEY ([Pices_Id])
    REFERENCES [dbo].[Pices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KorisnikPice_Pice'
CREATE INDEX [IX_FK_KorisnikPice_Pice]
ON [dbo].[KorisnikPice]
    ([Pices_Id]);
GO

-- Creating foreign key on [OperaterId] in table 'Tikets'
ALTER TABLE [dbo].[Tikets]
ADD CONSTRAINT [FK_OperaterTiket]
    FOREIGN KEY ([OperaterId])
    REFERENCES [dbo].[Radniks_Operater]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperaterTiket'
CREATE INDEX [IX_FK_OperaterTiket]
ON [dbo].[Tikets]
    ([OperaterId]);
GO

-- Creating foreign key on [Tiket_Id] in table 'Dogadjajs'
ALTER TABLE [dbo].[Dogadjajs]
ADD CONSTRAINT [FK_DogadjajTiket]
    FOREIGN KEY ([Tiket_Id])
    REFERENCES [dbo].[Tikets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DogadjajTiket'
CREATE INDEX [IX_FK_DogadjajTiket]
ON [dbo].[Dogadjajs]
    ([Tiket_Id]);
GO

-- Creating foreign key on [LokalId] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_LokalRadnik]
    FOREIGN KEY ([LokalId])
    REFERENCES [dbo].[Lokals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LokalRadnik'
CREATE INDEX [IX_FK_LokalRadnik]
ON [dbo].[Radniks]
    ([LokalId]);
GO

-- Creating foreign key on [Id] in table 'Radniks_Barmen'
ALTER TABLE [dbo].[Radniks_Barmen]
ADD CONSTRAINT [FK_Barmen_inherits_Radnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Radniks]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Radniks_Operater'
ALTER TABLE [dbo].[Radniks_Operater]
ADD CONSTRAINT [FK_Operater_inherits_Radnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Radniks]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------