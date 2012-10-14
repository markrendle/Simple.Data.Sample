CREATE TABLE [dbo].[Orders]
(
[OrderId] [int] NOT NULL IDENTITY(1, 1),
[OrderDate] [datetime] NOT NULL,
[Username] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[FirstName] [nvarchar] (160) COLLATE Latin1_General_CI_AS NULL,
[LastName] [nvarchar] (160) COLLATE Latin1_General_CI_AS NULL,
[Address] [nvarchar] (70) COLLATE Latin1_General_CI_AS NULL,
[City] [nvarchar] (40) COLLATE Latin1_General_CI_AS NULL,
[State] [nvarchar] (40) COLLATE Latin1_General_CI_AS NULL,
[PostalCode] [nvarchar] (10) COLLATE Latin1_General_CI_AS NULL,
[Country] [nvarchar] (40) COLLATE Latin1_General_CI_AS NULL,
[Phone] [nvarchar] (24) COLLATE Latin1_General_CI_AS NULL,
[Email] [nvarchar] (160) COLLATE Latin1_General_CI_AS NULL,
[Total] [numeric] (10, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [PK__Invoice__D796AAB51A14E395] PRIMARY KEY CLUSTERED  ([OrderId]) ON [PRIMARY]
GO
