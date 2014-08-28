CREATE TABLE [dbo].[Products] (
    [Id]            INT           NOT NULL,
    [Caption]       NVARCHAR (50) NOT NULL,
    [Manufacturer]  NVARCHAR (50) NOT NULL,
    [TypeNumber]    NVARCHAR (50) NOT NULL,
    [LensMount]     NVARCHAR (50) NULL,
    [FocalLength]   NVARCHAR (50) NULL,
    [MaxAperture]   NVARCHAR (50) NULL,
    [Lens]          NVARCHAR (50) NULL,
    [Discriminator] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);