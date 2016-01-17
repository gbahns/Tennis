CREATE TABLE [dbo].[Matches]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[EventID] [int] NOT NULL,
[Date] [datetime] NOT NULL,
[LocationID] [int] NULL,
[SurfaceID] [int] NULL,
[WinnerID] [int] NOT NULL,
[LoserID] [int] NOT NULL,
[WinnerSet1] [tinyint] NULL,
[LoserSet1] [tinyint] NULL,
[WinnerSet2] [tinyint] NULL,
[LoserSet2] [tinyint] NULL,
[WinnerSet3] [tinyint] NULL,
[LoserSet3] [tinyint] NULL,
[WinnerSet4] [tinyint] NULL,
[LoserSet4] [tinyint] NULL,
[WinnerSet5] [tinyint] NULL,
[LoserSet5] [tinyint] NULL,
[WinnerTiebreak1] [tinyint] NULL,
[LoserTiebreak1] [tinyint] NULL,
[WinnerTiebreak2] [tinyint] NULL,
[LoserTiebreak2] [tinyint] NULL,
[WinnerTiebreak3] [tinyint] NULL,
[LoserTiebreak3] [tinyint] NULL,
[WinnerTiebreak4] [tinyint] NULL,
[LoserTiebreak4] [tinyint] NULL,
[WinnerTiebreak5] [tinyint] NULL,
[LoserTiebreak5] [tinyint] NULL,
[Defaulted] [bit] NOT NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'MS_Filter', NULL, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderBy', NULL, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_TableMaxRecords', 10000, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.Events', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_ListRows', N'20', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.PlayerList', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_ListRows', N'20', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.PlayerList', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'106', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'
GO
EXEC sp_addextendedproperty N'MS_Format', N'Yes/No', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'

