CREATE PROCEDURE dbo.csla_get_matchlist_personal
	@PlayerID int
AS 
	select
		Matches.ID ID,
		Matches.Date MatchDate,
		Events.ID EventID,
		Events.Name EventName,
		Classifications.ID ClassID,
		Classifications.Name ClassName,
		--subjective view of the match winner & loser
		case when WinnerID=@playerid then 'W' else 'L' end Result,
		case when WinnerID=@playerid then LoserID else WinnerID end OpponentID,
		case when WinnerID=@playerid then Loser.FirstName+' '+Loser.LastName else Winner.FirstName+' '+Winner.LastName end OpponentName,
		case when WinnerID=@playerid then WinnerSet1 else LoserSet1 end WSet1,
		case when LoserID=@playerid then WinnerSet1 else LoserSet1 end LSet1,
		case when WinnerID=@playerid then WinnerTiebreak1 else LoserTiebreak1 end WTiebreak1,
		case when LoserID=@playerid then WinnerTiebreak1 else LoserTiebreak1 end LTiebreak1,
		case when WinnerID=@playerid then WinnerSet2 else LoserSet2 end WSet2,
		case when LoserID=@playerid then WinnerSet2 else LoserSet2 end LSet2,
		case when WinnerID=@playerid then WinnerTiebreak2 else LoserTiebreak2 end WTiebreak2,
		case when LoserID=@playerid then WinnerTiebreak2 else LoserTiebreak2 end LTiebreak2,
		case when WinnerID=@playerid then WinnerSet3 else LoserSet3 end WSet3,
		case when LoserID=@playerid then WinnerSet3 else LoserSet3 end LSet3,
		case when WinnerID=@playerid then WinnerTiebreak3 else LoserTiebreak3 end WTiebreak3,
		case when LoserID=@playerid then WinnerTiebreak3 else LoserTiebreak3 end LTiebreak3,
		case when WinnerID=@playerid then WinnerSet4 else LoserSet4 end WSet4,
		case when LoserID=@playerid then WinnerSet4 else LoserSet4 end LSet4,
		case when WinnerID=@playerid then WinnerTiebreak4 else LoserTiebreak4 end WTiebreak4,
		case when LoserID=@playerid then WinnerTiebreak4 else LoserTiebreak4 end LTiebreak4,
		case when WinnerID=@playerid then WinnerSet5 else LoserSet5 end WSet5,
		case when LoserID=@playerid then WinnerSet5 else LoserSet5 end LSet5,
		case when WinnerID=@playerid then WinnerTiebreak5 else LoserTiebreak5 end WTiebreak5,
		case when LoserID=@playerid then WinnerTiebreak5 else LoserTiebreak5 end LTiebreak5,
		Matches.Defaulted
	FROM
		Matches 
		LEFT OUTER JOIN Players Loser ON Matches.LoserID = Loser.ID 
		LEFT OUTER JOIN Players Winner ON Matches.WinnerID = Winner.ID 
		LEFT OUTER JOIN Events ON Matches.EventID = Events.ID
		left outer join Classifications on Events.ClassificationID = Classifications.ID
	where	
		Matches.WinnerID=@PlayerID or Matches.LoserID=@PlayerID
	ORDER BY 
		Matches.Date


