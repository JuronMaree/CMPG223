CREATE TABLE [dbo].[Unit] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UnitNumber] NCHAR (10)     NOT NULL,
    [OwnerName]  NVARCHAR (50)  NULL,
    [OwnerCell]  NVARCHAR (50)  NULL,
    [Memo]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UnitNumber] ASC)
);
