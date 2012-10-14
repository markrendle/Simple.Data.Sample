CREATE TABLE [dbo].[Albums]
(
[AlbumId] [int] NOT NULL IDENTITY(1, 1),
[GenreId] [int] NOT NULL,
[ArtistId] [int] NOT NULL,
[Title] [nvarchar] (160) COLLATE Latin1_General_CI_AS NOT NULL,
[Price] [numeric] (10, 2) NOT NULL,
[AlbumArtUrl] [nvarchar] (1024) COLLATE Latin1_General_CI_AS NULL CONSTRAINT [DF_Album_AlbumArtUrl] DEFAULT (N'/Content/Images/placeholder.gif')
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums] ADD CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED  ([AlbumId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums] WITH NOCHECK ADD CONSTRAINT [FK__Album__ArtistId__276EDEB3] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Albums] WITH NOCHECK ADD CONSTRAINT [FK_Album_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([GenreId])
GO
