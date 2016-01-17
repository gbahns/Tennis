CREATE PROCEDURE dbo.csla_save_match
	(
		@ID int, --null for new match
		@EventID int,
		@Date datetime,
		@WinnerID int,
		@LoserID int,
		@WSet1 tinyint,
		@LSet1 tinyint,
		@WTiebreak1 tinyint,
		@LTiebreak1 tinyint,
		@WSet2 tinyint,
		@LSet2 tinyint,
		@WTiebreak2 tinyint,
		@LTiebreak2 tinyint,
		@WSet3 tinyint,
		@LSet3 tinyint,
		@WTiebreak3 tinyint,
		@LTiebreak3 tinyint,
		@WSet4 tinyint,
		@LSet4 tinyint,
		@WTiebreak4 tinyint,
		@LTiebreak4 tinyint,
		@WSet5 tinyint,
		@LSet5 tinyint,
		@WTiebreak5 tinyint,
		@LTiebreak5 tinyint,
		@Defaulted bit,
		@IDout int output
	)
AS
	SET NOCOUNT ON
	if @ID is NULL	
	begin
		insert matches (
			EventID,
			Date,
			WinnerID,
			LoserID,
			WinnerSet1,
			LoserSet1,
			WinnerSet2,
			LoserSet2,
			WinnerSet3,
			LoserSet3,
			WinnerSet4,
			LoserSet4,
			WinnerSet5,
			LoserSet5,
			WinnerTiebreak1,
			LoserTiebreak1,
			WinnerTiebreak2,
			LoserTiebreak2,
			WinnerTiebreak3,
			LoserTiebreak3,
			WinnerTiebreak4,
			LoserTiebreak4,
			WinnerTiebreak5,
			LoserTiebreak5,
			Defaulted
			)
		values (
			@EventID,
			@Date,
			@WinnerID,
			@LoserID,
			@WSet1,
			@LSet1,
			@WSet2,
			@LSet2,
			@WSet3,
			@LSet3,
			@WSet4,
			@LSet4,
			@WSet5,
			@LSet5,
			@WTiebreak1,
			@LTiebreak1,
			@WTiebreak2,
			@LTiebreak2,
			@WTiebreak3,
			@LTiebreak3,
			@WTiebreak4,
			@LTiebreak4,
			@WTiebreak5,
			@LTiebreak5,
			@Defaulted
			)
		set @IDout = @@IDENTITY
	end else begin
		update 
			matches
		set
			EventID = @EventID,
			Date = @Date,
			WinnerID = @WinnerID,
			LoserID = @LoserID,
			WinnerSet1 = @WSet1,
			LoserSet1 = @LSet1,
			WinnerSet2 = @WSet2,
			LoserSet2 = @LSet2,
			WinnerSet3 = @WSet3,
			LoserSet3 = @LSet3,
			WinnerSet4 = @WSet4,
			LoserSet4 = @LSet4,
			WinnerSet5 = @WSet5,
			LoserSet5 = @LSet5,
			WinnerTiebreak1 = @WTiebreak1,
			LoserTiebreak1 = @LTiebreak1,
			WinnerTiebreak2 = @WTiebreak2,
			LoserTiebreak2 = @LTiebreak2,
			WinnerTiebreak3 = @WTiebreak3,
			LoserTiebreak3 = @LTiebreak3,
			WinnerTiebreak4 = @WTiebreak4,
			LoserTiebreak4 = @LTiebreak4,
			WinnerTiebreak5 = @WTiebreak5,
			LoserTiebreak5 = @LTiebreak5,
			Defaulted = @Defaulted
		where
			ID=@ID
	end


