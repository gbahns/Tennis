
DECLARE @xp tinyint
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DefaultView', @xp, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_OrderByOn', @xp, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'TABLE', N'Matches', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=390
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'ID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'

GO
DECLARE @xp smallint
SELECT @xp=2970
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'EventID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Date'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Date'

GO
DECLARE @xp smallint
SELECT @xp=2310
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Date'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'

GO
DECLARE @xp smallint
SELECT @xp=3360
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'

GO
DECLARE @xp smallint
SELECT @xp=3360
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'

GO
DECLARE @xp smallint
SELECT @xp=990
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Matches', 'COLUMN', N'Defaulted'

GO
DECLARE @xp tinyint
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DefaultView', @xp, 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_OrderByOn', @xp, 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'TABLE', N'Players', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'ID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'FirstName'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'

GO
DECLARE @xp smallint
SELECT @xp=2760
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Players', 'COLUMN', N'LastName'

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'TABLE', N'Teams', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DefaultView', @xp, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_OrderByOn', @xp, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'TABLE', N'Users', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'id'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'uid'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'pwd'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'

GO
DECLARE @xp smallint
SELECT @xp=2775
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'TABLE', N'Users', 'COLUMN', N'playerid'

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=390
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'ID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Date'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Date'

GO
DECLARE @xp smallint
SELECT @xp=2310
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Date'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'

GO
DECLARE @xp smallint
SELECT @xp=2970
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'EventID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'

GO
DECLARE @xp smallint
SELECT @xp=3360
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerFirstName'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'

GO
DECLARE @xp smallint
SELECT @xp=2760
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerLastName'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'

GO
DECLARE @xp smallint
SELECT @xp=3360
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserFirstName'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'

GO
DECLARE @xp smallint
SELECT @xp=2760
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserLastName'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet1'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet1'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet2'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet2'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet3'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet3'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet4'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet4'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp smallint
SELECT @xp=1200
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'WinnerSet5'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp smallint
SELECT @xp=1065
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'LoserSet5'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'

GO
DECLARE @xp smallint
SELECT @xp=990
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'MatchList', 'COLUMN', N'Defaulted'

GO
DECLARE @xp tinyint
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DefaultView', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_OrderByOn', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'

GO
DECLARE @xp smallint
SELECT @xp=-1
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'ID'

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnHidden', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'Name'

GO
DECLARE @xp smallint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_ColumnOrder', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'Name'

GO
DECLARE @xp smallint
SELECT @xp=3105
EXEC sp_addextendedproperty N'MS_ColumnWidth', @xp, 'USER', N'dbo', 'VIEW', N'PlayerList', 'COLUMN', N'Name'

GO
DECLARE @xp tinyint
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DefaultView', @xp, 'USER', N'dbo', 'PROCEDURE', N'sp_get_matchlist_xml', NULL, NULL

GO
DECLARE @xp bit
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_OrderByOn', @xp, 'USER', N'dbo', 'PROCEDURE', N'sp_get_matchlist_xml', NULL, NULL

GO
DECLARE @xp tinyint
SELECT @xp=0
EXEC sp_addextendedproperty N'MS_Orientation', @xp, 'USER', N'dbo', 'PROCEDURE', N'sp_get_matchlist_xml', NULL, NULL


GO
