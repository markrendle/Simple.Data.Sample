CREATE TABLE [dbo].[Genres]
(
[GenreId] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (120) COLLATE Latin1_General_CI_AS NULL,
[Description] [nvarchar] (4000) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Genres] ADD CONSTRAINT [PK__Genres__0385057E1EA48E88] PRIMARY KEY CLUSTERED  ([GenreId]) ON [PRIMARY]
GO
