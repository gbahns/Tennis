ALTER TABLE [dbo].[Matches] WITH NOCHECK ADD
CONSTRAINT [FK_NewMatchesLoser_Players] FOREIGN KEY ([LoserID]) REFERENCES [dbo].[Players] ([ID])


