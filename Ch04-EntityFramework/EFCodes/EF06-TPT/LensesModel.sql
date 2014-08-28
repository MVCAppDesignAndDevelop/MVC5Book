CREATE TABLE [dbo].[Lenses] (
    [Id]            INT           NOT NULL,
    [Caption]       NVARCHAR (50) NOT NULL,
    [Manufacturer]  NVARCHAR (50) NOT NULL,
    [TypeNumber]    NVARCHAR (50) NOT NULL,
    [FocalLength]   NVARCHAR (50) NULL,
    [MaxAperture]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
