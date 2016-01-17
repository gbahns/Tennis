CREATE PROCEDURE dbo.csla_get_event
	@id int
AS
	SET NOCOUNT ON
	--return requested event data
	select 
		ID,
		Name,
		ClassificationID,
		BeginDate,
		EndDate,
		Type,
		TeamPlay
	from 
		Events
	where 
		ID=@id


