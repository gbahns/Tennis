CREATE PROCEDURE [dbo].[csla_get_player_summary_events]
	@playerid int,
	@eventtype int = null
AS
	
SET NOCOUNT ON
	
select
	--EventID,
	EventName Name,
	EventBeginDate,
	EventType,
	EventTeamPlay,
	
	--count(*) MatchesPlayed,
	sum(WMatch) WMatches,
	sum(LMatch) LMatches,
	sum(WSets) WSets,
	sum(LSets) LSets,
	sum(WGames) WGames,
	sum(LGames) LGames
from
	fn_get_player_history(@playerid,null,null,@eventtype)
group by
	PlayerID,
	PlayerName,
	EventID,
	EventName,
	EventBeginDate,
	EventType,
	EventTeamPlay
order by
	EventBeginDate,
	EventName


