CREATE PROCEDURE csla_get_matchlist
AS
	set nocount on 
	select
		Matches.ID ID,
		Matches.Date MatchDate,
		Events.ID EventID,
		Events.Name EventName,
		Classifications.ID ClassID,
		Classifications.Name ClassName,
		Winner.ID WinnerID,
		Winner.FirstName + ' ' + Winner.LastName Winner,
		Loser.ID LoserID,
		Loser.FirstName + ' ' + Loser.LastName Loser, 
		WinnerSet1,
		LoserSet1,
		WinnerSet2,
		LoserSet2,
		WinnerSet3,
		LoserSet3,
		WinnerSet4,
		LoserSet4,
		WinnerSet5,
		LoserSet5,
		WinnerTiebreak1,
		LoserTiebreak1,
		WinnerTiebreak2,
		LoserTiebreak2,
		WinnerTiebreak3,
		LoserTiebreak3,
		WinnerTiebreak4,
		LoserTiebreak4,
		WinnerTiebreak5,
		LoserTiebreak5,
		Matches.Defaulted
	FROM
		Matches 
		LEFT OUTER JOIN Players Loser ON Matches.LoserID = Loser.ID 
		LEFT OUTER JOIN Players Winner ON Matches.WinnerID = Winner.ID 
		LEFT OUTER JOIN Events ON Matches.EventID = Events.ID
		left outer join Classifications on Events.ClassificationID = Classifications.ID
	ORDER BY 
		Matches.Date


