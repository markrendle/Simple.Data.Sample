CREATE TABLE [dbo].[Artists]
(
[ArtistId] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (120) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artists] ADD CONSTRAINT [PK__Artists__25706B50245D67DE] PRIMARY KEY CLUSTERED  ([ArtistId]) ON [PRIMARY]
GO
