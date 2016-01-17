CREATE  VIEW [dbo].[MatchList]
AS
SELECT     TOP 100 PERCENT dbo.Matches.ID, dbo.Matches.Date, dbo.Matches.EventID, dbo.Events.BeginDate AS EventBeginDate, 
                      dbo.Events.EndDate AS EventEndDate, dbo.Events.Type EventType, dbo.Events.TeamPlay AS EventTeamPlay, dbo.Classifications.ID AS ClassificationID, dbo.Classifications.Name AS Classification, 
                      dbo.Events.Name AS EventName, dbo.Matches.WinnerID, Winner.FirstName AS WinnerFirstName, Winner.LastName AS WinnerLastName, 
                      dbo.Matches.LoserID, Loser.FirstName AS LoserFirstName, Loser.LastName AS LoserLastName, dbo.Matches.WinnerSet1, dbo.Matches.LoserSet1, 
                      dbo.Matches.WinnerSet2, dbo.Matches.LoserSet2, dbo.Matches.WinnerSet3, dbo.Matches.LoserSet3, dbo.Matches.WinnerSet4, 
                      dbo.Matches.LoserSet4, dbo.Matches.WinnerSet5, dbo.Matches.LoserSet5, dbo.Matches.Defaulted, 
                      CASE WHEN WinnerSet1 > LoserSet1 THEN 1 ELSE 0 END AS WinnerSets1, CASE WHEN WinnerSet1 < LoserSet1 THEN 1 ELSE 0 END AS LoserSets1,
                       CASE WHEN WinnerSet2 > LoserSet2 THEN 1 ELSE 0 END AS WinnerSets2, CASE WHEN WinnerSet2 < LoserSet2 THEN 1 ELSE 0 END AS LoserSets2,
                       CASE WHEN WinnerSet3 > LoserSet3 THEN 1 ELSE 0 END AS WinnerSets3, CASE WHEN WinnerSet3 < LoserSet3 THEN 1 ELSE 0 END AS LoserSets3,
                       CASE WHEN WinnerSet4 > LoserSet4 THEN 1 ELSE 0 END AS WinnerSets4, CASE WHEN WinnerSet4 < LoserSet4 THEN 1 ELSE 0 END AS LoserSets4,
                       CASE WHEN WinnerSet5 > LoserSet5 THEN 1 ELSE 0 END AS WinnerSets5, 
                      CASE WHEN WinnerSet5 < LoserSet5 THEN 1 ELSE 0 END AS LoserSets5
FROM         dbo.Matches INNER JOIN
                      dbo.Events ON dbo.Matches.EventID = dbo.Events.ID INNER JOIN
                      dbo.Players Loser ON dbo.Matches.LoserID = Loser.ID INNER JOIN
                      dbo.Players Winner ON dbo.Matches.WinnerID = Winner.ID LEFT OUTER JOIN
                      dbo.Classifications ON dbo.Events.ClassificationID = dbo.Classifications.ID
ORDER BY dbo.Matches.Date


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
         Configuration = "(H (1[39] 4[39] 3) )"
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
         Configuration = "(H (1[50] 4) )"
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
         Begin Table = "Matches"
            Begin Extent = 
               Top = 11
               Left = 21
               Bottom = 309
               Right = 173
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Events"
            Begin Extent = 
               Top = 0
               Left = 254
               Bottom = 141
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Loser"
            Begin Extent = 
               Top = 237
               Left = 253
               Bottom = 332
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Winner"
            Begin Extent = 
               Top = 140
               Left = 254
               Bottom = 235
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Classifications"
            Begin Extent = 
               Top = 26
               Left = 462
               Bottom = 106
               Right = 614
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
         Column = 4545
         Alias = 1380
         Table = 1410
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         F', 'USER', N'dbo', 'VIEW', N'MatchList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPane2', N'ilter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'USER', N'dbo', 'VIEW', N'MatchList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', 2, 'USER', N'dbo', 'VIEW', N'MatchList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.Events', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'Name', N'Name', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'SourceField', N'Name', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Events', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventName'
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_ListRows', N'20', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.PlayerList', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'Name', N'FirstName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'SourceField', N'FirstName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'Name', N'LastName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'3', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'SourceField', N'LastName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'
GO
EXEC sp_addextendedproperty N'MS_ColumnCount', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_ColumnWidths', N'0.000', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'111', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_LimitToList', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_ListRows', N'20', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'MS_RowSource', N'dbo.PlayerList', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'Name', N'FirstName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'SourceField', N'FirstName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'
GO
EXEC sp_addextendedproperty N'AllowZeroLength', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'Attributes', N'2', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'CollatingOrder', N'1033', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'ColumnHidden', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'ColumnOrder', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'ColumnWidth', N'-1', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'DataUpdatable', N'False', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'109', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'Name', N'LastName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'OrdinalPosition', N'3', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'Required', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'Size', N'50', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'SourceField', N'LastName', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'SourceTable', N'Players', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'Type', N'10', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'UnicodeCompression', N'True', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'
GO
EXEC sp_addextendedproperty N'MS_DisplayControl', N'106', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'
GO
EXEC sp_addextendedproperty N'MS_Format', N'Yes/No', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'
GO
EXEC sp_addextendedproperty N'MS_IMEMode', N'0', 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'

