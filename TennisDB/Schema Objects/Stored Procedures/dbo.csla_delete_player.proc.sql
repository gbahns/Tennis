create PROCEDURE dbo.csla_delete_player
	@id int
AS
	SET NOCOUNT ON
	delete Players where ID=@ID


