CREATE PROCEDURE dbo.csla_get_classificationlist
AS
	SET NOCOUNT ON
	select 
		ID,
		Name,
		USTAEquivalent
	from 
		Classifications


