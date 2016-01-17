CREATE TABLE [dbo].[Users]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[uid] [varchar] (20) NOT NULL,
[pwd] [varchar] (20) NOT NULL,
[playerid] [int] NULL,
[email] [varchar] (50) NULL,
[approved] [bit] NOT NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Filter', NULL, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderBy', NULL, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_TableMaxRecords', 10000, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'unique record identifier', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'
GO
EXEC sp_addextendedproperty N'MS_Description', N'user''s login id', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'password', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_Description', N'identifies who this user is', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'SELECT ID, FirstName + N'' '' + LastName AS Name FROM Players ORDER BY FirstName + N'' '' + LastName', 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'

