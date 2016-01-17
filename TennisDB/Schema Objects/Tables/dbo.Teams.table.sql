CREATE TABLE [dbo].[Teams]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Description] [varchar] (50) NOT NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Format', N'', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Teams', 'COLUMN', N'Description'

