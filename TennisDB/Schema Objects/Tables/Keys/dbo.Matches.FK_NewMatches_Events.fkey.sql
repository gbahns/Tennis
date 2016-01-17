ALTER TABLE [dbo].[Matches] WITH NOCHECK ADD
CONSTRAINT [FK_NewMatches_Events] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID])


