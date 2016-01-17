create PROCEDURE dbo.csla_delete_event
	@id int
AS
	SET NOCOUNT ON
	delete events where ID=@ID


