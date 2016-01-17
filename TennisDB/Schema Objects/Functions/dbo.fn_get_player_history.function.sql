CREATE  FUNCTION [dbo].[fn_get_player_history]
	(@playerid int, @opponentid int=null, @eventid int=null, @eventtype smallint=null)
RETURNS TABLE
AS
/*
returns match list from the point of view of the specified player
the Result column indicates whether the player won or lost the match ('W' or 'L')
the OpponentID and OpponentName columns indicate who the player played against
the set scores are still according to match WinnerSetn and LoserSetn, which is
useful for displaying the results, though for computing totals according to
the player, they need to be switched to SetnW and SetnL.

WinnerSetn - number of games won by the match winner in set n
LoserSetn - number of games won by the match loser in set n

WSetn - number of games won by the specified player in set n
LSetn - number of games lost by the specified player in set n
WMatch - 1 if the specified player won the match
LMatch - 1 if the specified player lost the match
*/
RETURN (
	select
		ID,
		Date,
		EventID,
		EventName,
		EventBeginDate,
		EventEndDate,
		EventType,
		EventTeamPlay,
		ClassificationID,
		Classification,
		@playerid PlayerID,
		case when WinnerID=@playerid then WinnerFirstName+' '+WinnerLastName else LoserFirstName+' '+LoserLastName end PlayerName,
		case when WinnerID=@playerid then 'W' else 'L' end Result,
		case when WinnerID=@playerid then LoserID else WinnerID end OpponentID,
		case when WinnerID=@playerid then LoserFirstName+' '+LoserLastName else WinnerFirstName+' '+WinnerLastName end OpponentName,
		--games won in each set according to who won the match
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
		--games won and lost in each set by the specified player
		case when WinnerID=@playerid then WinnerSet1 else LoserSet1 end WSet1,
		case when LoserID=@playerid then WinnerSet1 else LoserSet1 end LSet1,
		case when WinnerID=@playerid then WinnerSet2 else LoserSet2 end WSet2,
		case when LoserID=@playerid then WinnerSet2 else LoserSet2 end LSet2,
		case when WinnerID=@playerid then WinnerSet3 else LoserSet3 end WSet3,
		case when LoserID=@playerid then WinnerSet3 else LoserSet3 end LSet3,
		case when WinnerID=@playerid then WinnerSet4 else LoserSet4 end WSet4,
		case when LoserID=@playerid then WinnerSet4 else LoserSet4 end LSet4,
		case when WinnerID=@playerid then WinnerSet5 else LoserSet5 end WSet5,
		case when LoserID=@playerid then WinnerSet5 else LoserSet5 end LSet5,
		--total games won and lost by the specified player
		case when WinnerID=@playerid 
			then isnull(WinnerSet1,0)+isnull(WinnerSet2,0)+isnull(WinnerSet3,0)+isnull(WinnerSet4,0)+isnull(WinnerSet5,0) 
			else isnull(LoserSet1,0)+isnull(LoserSet2,0)+isnull(LoserSet3,0)+isnull(LoserSet4,0)+isnull(LoserSet5,0) 
			end WGames,
		case when LoserID=@playerid  
			then isnull(WinnerSet1,0)+isnull(WinnerSet2,0)+isnull(WinnerSet3,0)+isnull(WinnerSet4,0)+isnull(WinnerSet5,0) 
			else isnull(LoserSet1,0)+isnull(LoserSet2,0)+isnull(LoserSet3,0)+isnull(LoserSet4,0)+isnull(LoserSet5,0) 
			end LGames,
		--total sets won and lost by the specified player
		case when WinnerID=@playerid 
			then WinnerSets1+WinnerSets2+WinnerSets3+WinnerSets4+WinnerSets5 
			else LoserSets1+LoserSets2+LoserSets3+LoserSets4+LoserSets5 
			end WSets,
		case when LoserID=@playerid  
			then WinnerSets1+WinnerSets2+WinnerSets3+WinnerSets4+WinnerSets5 
			else LoserSets1+LoserSets2+LoserSets3+LoserSets4+LoserSets5 
			end LSets,
		--total matches won and lost by the specified player
		case when WinnerID=@playerid then 1 else 0 end WMatch,
		case when WinnerID=@playerid then 0 else 1 end LMatch,
		Defaulted
	from
		MatchList
	where
		(WinnerID=@playerid or LoserID=@playerid)
		and (@opponentid is null or WinnerID=@opponentid or LoserID=@opponentid)
		and (@eventid is null or EventID=@eventid)
		and (@eventtype is null or EventType=@eventtype)
	)


