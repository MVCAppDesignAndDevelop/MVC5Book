CREATE TABLE [dbo].[SingleReflexCamera] (
    [Id]            INT           NOT NULL,
    [Caption]       NVARCHAR (50) NOT NULL,
    [Manufacturer]  NVARCHAR (50) NOT NULL,
    [TypeNumber]    NVARCHAR (50) NOT NULL,
    [LensMount]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);