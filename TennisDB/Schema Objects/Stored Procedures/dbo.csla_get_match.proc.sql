CREATE PROCEDURE dbo.csla_get_match
	@id int
AS
	SET NOCOUNT ON
	--return requested match data
	select 
		ID, 
		EventID, 
		Date,
		WinnerID, LoserID,
		WinnerSet1, LoserSet1, WinnerTiebreak1, LoserTiebreak1,
		WinnerSet2, LoserSet2, WinnerTiebreak2, LoserTiebreak2,
		WinnerSet3, LoserSet3, WinnerTiebreak3, LoserTiebreak3,
		WinnerSet4, LoserSet4, WinnerTiebreak4, LoserTiebreak4,
		WinnerSet5, LoserSet5, WinnerTiebreak5, LoserTiebreak5,
		Defaulted
	from 
		Matches 
	where 
		ID=@id


