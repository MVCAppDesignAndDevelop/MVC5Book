CREATE TABLE [dbo].[Article]
(
	[ID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Subject] NVARCHAR(50) NOT NULL, 
    [Summary] NVARCHAR(500) NOT NULL, 
    [ContentText] NVARCHAR(MAX) NOT NULL, 
    [IsPublich] BIT NOT NULL, 
    [PublishDate] DATETIME NOT NULL, 
    [ViewCount] INT NOT NULL, 
    [CreateUser] UNIQUEIDENTIFIER NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [UpdateUser] UNIQUEIDENTIFIER NULL, 
    [UpdateDate] DATETIME NOT NULL
)
