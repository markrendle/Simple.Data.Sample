CREATE TABLE [dbo].[OrderDetails]
(
[OrderDetailId] [int] NOT NULL IDENTITY(1, 1),
[OrderId] [int] NOT NULL,
[AlbumId] [int] NOT NULL,
[Quantity] [int] NOT NULL,
[UnitPrice] [numeric] (10, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails] ADD CONSTRAINT [PK__InvoiceL__0D760AD91DE57479] PRIMARY KEY CLUSTERED  ([OrderDetailId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails] ADD CONSTRAINT [FK_OrderDetail_Album] FOREIGN KEY ([AlbumId]) REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[OrderDetails] WITH NOCHECK ADD CONSTRAINT [FK__InvoiceLi__Invoi__2F10007B] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId])
GO
