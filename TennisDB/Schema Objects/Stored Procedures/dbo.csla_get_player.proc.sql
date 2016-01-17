CREATE PROCEDURE dbo.csla_get_player
	@id int
AS
	SET NOCOUNT ON
	--return requested player data
	select 
		ID,
		FirstName,
		LastName
	from 
		Players
	where 
		ID=@id


