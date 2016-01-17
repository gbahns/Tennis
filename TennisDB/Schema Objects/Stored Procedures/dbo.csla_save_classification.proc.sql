CREATE PROCEDURE dbo.csla_save_classification
	@id int output,
	@Name varchar(50),
	@USTAEquivalent varchar(4)
AS
	SET NOCOUNT ON
	if @ID is NULL	
	begin
		insert Classifications values (
			@Name,
			@USTAEquivalent
			)
		set @ID = @@IDENTITY
	end else begin
		update 
			Classifications
		set
			Name = @Name,
			USTAEquivalent = @USTAEquivalent
		where
			ID=@ID
	end


