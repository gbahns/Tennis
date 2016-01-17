CREATE PROCEDURE dbo.csla_get_player_summary_opponents
	(@playerid int)
AS
	SET NOCOUNT ON
	
	select
		OpponentID,
		OpponentName Name,
		--count(*) MatchesPlayed,
		sum(WMatch) WMatches,
		sum(LMatch) LMatches,
		--convert(float,sum(WMatch)) / (sum(WMatch)+sum(LMatch)) PctMatches,
		sum(WSets) WSets,
		sum(LSets) LSets,
		--convert(float,sum(WSets)) / (sum(WSets)+sum(LSets)) PctSets,
		sum(WGames) WGames,
		sum(LGames) LGames
		--convert(float,sum(WGames)) / (sum(WGames)+sum(LGames)) PctGames
	from
		fn_get_player_history(@playerid,null,null,null)
	group by
		OpponentID,
		OpponentName
	/*order by
		MatchesPlayed desc, 
		PctMatches desc,
		PctSets desc,
		PctGames desc,
		Name asc*/


