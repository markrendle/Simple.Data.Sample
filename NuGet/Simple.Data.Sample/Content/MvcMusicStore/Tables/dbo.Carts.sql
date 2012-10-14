CREATE TABLE [dbo].[Carts]
(
[RecordId] [int] NOT NULL IDENTITY(1, 1),
[CartId] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[AlbumId] [int] NOT NULL,
[Count] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carts] ADD CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED  ([RecordId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carts] ADD CONSTRAINT [FK_Cart_Album] FOREIGN KEY ([AlbumId]) REFERENCES [dbo].[Albums] ([AlbumId])
GO
