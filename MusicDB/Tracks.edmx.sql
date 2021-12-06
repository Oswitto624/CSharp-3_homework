
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2021 21:47:05
-- Generated from EDMX file: C:\Users\sucha\OneDrive\Рабочий стол\GeekBrains\C#-3\CSharp-3\MusicDB\Tracks.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Traks];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TrackSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrackSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TrackSet'
CREATE TABLE [dbo].[TrackSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TrackName] nvarchar(max)  NOT NULL,
    [ArtistName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TrackSet'
ALTER TABLE [dbo].[TrackSet]
ADD CONSTRAINT [PK_TrackSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------