ALTER TABLE [dbo].[Matches] WITH NOCHECK ADD
CONSTRAINT [FK_NewMatchesWinner_Players] FOREIGN KEY ([WinnerID]) REFERENCES [dbo].[Players] ([ID])


