CREATE PROCEDURE [dbo].[csla_get_playerlist]
AS
	SET NOCOUNT ON
	--return list of players
	select 
		ID,
		FirstName,
		LastName
	from 
		Players
	order by
		FirstName, LastName


