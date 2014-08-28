
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/16/2014 17:04:27
-- Generated from EDMX file: D:\NAS DataBackup\著作資料夾\ASP.NET MVC 5.0 開發美學\Ch04-Codes\EFCodes\EF02-ModelFirst\BlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlogDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BlogBlogArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogArticles] DROP CONSTRAINT [FK_BlogBlogArticle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Blogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blogs];
GO
IF OBJECT_ID(N'[dbo].[BlogArticles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogArticles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [Id] uniqueidentifier  NOT NULL,
    [OwnerId] uniqueidentifier  NOT NULL,
    [Caption] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'BlogArticles'
CREATE TABLE [dbo].[BlogArticles] (
    [Id] uniqueidentifier  NOT NULL,
    [BlogId] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [Blog_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogArticles'
ALTER TABLE [dbo].[BlogArticles]
ADD CONSTRAINT [PK_BlogArticles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Blog_Id] in table 'BlogArticles'
ALTER TABLE [dbo].[BlogArticles]
ADD CONSTRAINT [FK_BlogBlogArticle]
    FOREIGN KEY ([Blog_Id])
    REFERENCES [dbo].[Blogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogBlogArticle'
CREATE INDEX [IX_FK_BlogBlogArticle]
ON [dbo].[BlogArticles]
    ([Blog_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------