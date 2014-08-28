CREATE TABLE [dbo].[ActionLogs] (
    [LogId]          INT           IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (50) NOT NULL,
    [ControllerName] NVARCHAR (50) NOT NULL,
    [ActionName]     NVARCHAR (50) NOT NULL,
    [IPAddress]      NVARCHAR (50) NOT NULL,
    [CreatedDate]    DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([LogId] ASC)
);
