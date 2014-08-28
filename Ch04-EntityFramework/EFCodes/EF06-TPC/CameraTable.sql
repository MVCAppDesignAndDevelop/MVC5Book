CREATE TABLE [dbo].[Cameras] (
    [Id]            INT           NOT NULL,
    [Caption]       NVARCHAR (50) NOT NULL,
    [Manufacturer]  NVARCHAR (50) NOT NULL,
    [TypeNumber]    NVARCHAR (50) NOT NULL,
    [Lens]          NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);