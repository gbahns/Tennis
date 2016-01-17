CREATE PROCEDURE dbo.csla_delete_match
	@id int
AS
	SET NOCOUNT ON
	delete Matches where ID=@ID


