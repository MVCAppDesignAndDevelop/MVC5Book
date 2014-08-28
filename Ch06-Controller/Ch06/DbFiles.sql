 CREATE TABLE [dbo].[DbFiles] (
     [Id]       INT           IDENTITY (1, 1) NOT NULL,
     [Name]     NVARCHAR (50) NOT NULL,
     [MimeType] NVARCHAR (50) NOT NULL,
     [Size]     INT           NOT NULL,
     [Content]  IMAGE         NOT NULL,
     PRIMARY KEY CLUSTERED ([Id] ASC)
 );
