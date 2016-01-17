CREATE PROCEDURE dbo.csla_delete_classification
	@id int
AS
	SET NOCOUNT ON
	delete Classifications where ID=@ID


