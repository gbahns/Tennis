/*
This is a new version of csla_get_player_summary_opponents.  It's the same
except it conforms to the new standard summary result set expected by the
new standard MatchSummary class.
*/
CREATE PROCEDURE [dbo].[csla_get_match_summary_events]
	@playerid int,
	@eventtype int = null
AS
SET NOCOUNT ON

select
	EventID,
	EventName Name,
	EventBeginDate StartDate,
	EventEndDate EndDate,
	EventType,
	EventTeamPlay,
	ClassificationID,
	Classification,
	
	min(Date) FirstMatchDate,
	max(Date) LastMatchDate,
	sum(WMatch) WMatches,
	sum(LMatch) LMatches,
	sum(WSets) WSets,
	sum(LSets) LSets,
	sum(WGames) WGames,
	sum(LGames) LGames
from
	fn_get_player_history(@playerid,null,null,@eventtype)
group by
	EventID,
	EventName,
	EventBeginDate,
	EventEndDate,
	EventType,
	EventTeamPlay,
	ClassificationID,
	Classification
order by
	max(Date) desc,
	EventName


