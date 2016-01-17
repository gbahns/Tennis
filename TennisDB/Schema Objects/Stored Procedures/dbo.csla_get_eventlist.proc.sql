CREATE PROCEDURE dbo.csla_get_eventlist
AS 
select
	ID,
	Name,
	ClassificationID,
	BeginDate,
	EndDate,
	Type,
	TeamPlay
FROM
	Events
order by
	BeginDate


