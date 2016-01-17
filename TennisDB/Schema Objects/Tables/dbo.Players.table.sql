CREATE TABLE [dbo].[Players]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [nvarchar] (50) NOT NULL,
[LastName] [nvarchar] (50) NOT NULL
) ON [PRIMARY]


GO
EXEC sp_addextendedproperty N'Attributes', N'0', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'DateCreated', N'8/17/2001 5:13:05 PM', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'LastUpdated', N'9/3/2001 7:41:12 PM', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Filter', NULL, 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderBy', N'Players.FirstName', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_TableMaxRecords', 10000, 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'Name', N'Players', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'OrderByOn', N'False', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'Orientation', N'0', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'RecordCount', N'29', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'Updatable', N'True', 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Attributes', N'17', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Name', N'ID', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Size', N'4', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'SourceField', N'ID', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Type', N'4', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'Name', N'FirstName', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'2', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'SourceField', N'FirstName', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'Name', N'LastName', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'3', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'SourceField', N'LastName', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'

