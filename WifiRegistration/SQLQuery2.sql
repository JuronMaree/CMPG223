CREATE TABLE [dbo].[ValidMac] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Unit]       NCHAR (10)    NULL,
    [Mac]        NVARCHAR (50) NULL,
    [Expire]     DATE          NULL,
    [DeviceType] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([Unit]) REFERENCES [dbo].[Unit] ([UnitNumber])
);