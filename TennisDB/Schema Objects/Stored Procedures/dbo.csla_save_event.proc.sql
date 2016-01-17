CREATE PROCEDURE dbo.csla_save_event
	@ID int,
	@Name varchar(50),
	@ClassificationID int,
	@BeginDate datetime,
	@EndDate datetime,
	@Type smallint,
	@TeamPlay bit,
	@IDout int output
AS
	SET NOCOUNT ON
	if @ID is NULL	
	begin
		insert Events values (
			@Name,
			@ClassificationID,
			@BeginDate,
			@EndDate,
			@Type,
			@TeamPlay
			)
		set @IDout = @@IDENTITY
	end else begin
		update 
			Events
		set
			Name = @Name,
			ClassificationID = @ClassificationID,
			BeginDate = @BeginDate,
			EndDate = @EndDate,
			Type = @Type,
			TeamPlay = @TeamPlay
		where
			ID=@ID
	end


