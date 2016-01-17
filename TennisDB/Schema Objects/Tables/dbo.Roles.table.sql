CREATE TABLE [dbo].[Roles]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (16) NOT NULL,
[Description] [varchar] (132) NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Description', N'unique record identifier', 'USER', N'dbo', 'TABLE', N'Roles', 'COLUMN', N'id'

