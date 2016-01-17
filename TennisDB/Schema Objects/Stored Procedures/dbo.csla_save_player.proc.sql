CREATE PROCEDURE dbo.csla_save_player
		@ID int, --null for new player
		@FirstName varchar(25),
		@LastName varchar(25),
		@IDout int output
AS
	SET NOCOUNT ON
	if @ID is NULL	
	begin
		insert Players values (
			@FirstName,
			@LastName
			)
		set @IDout = @@IDENTITY
	end else begin
		update 
			Players
		set
			FirstName = @FirstName,
			LastName = @LastName
		where
			ID=@ID
	end


