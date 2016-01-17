CREATE VIEW dbo.PlayerList
AS
SELECT     ID, FirstName + N' ' + LastName AS Name
FROM         dbo.Players


GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1 [56] 4 [18] 2))"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1[75] 4) )"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 9
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Players"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 101
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
      PaneHidden = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
      RowHeights = 220
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2580
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', 1, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Filter', NULL, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_OrderBy', NULL, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_TableMaxRecords', 10000, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Attributes', N'17', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Name', N'ID', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'1', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Required', N'False', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Size', N'4', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'SourceField', N'ID', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'Type', N'4', 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'

