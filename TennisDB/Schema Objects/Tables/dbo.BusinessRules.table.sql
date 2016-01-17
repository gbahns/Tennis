CREATE TABLE [dbo].[BusinessRules]
(
[ClassName] [varchar] (200) NOT NULL,
[FieldName] [varchar] (50) NOT NULL,
[Required] [bit] NOT NULL,
[MinValue] [varchar] (10) NOT NULL,
[MaxValue] [varchar] (10) NOT NULL,
[Mask] [varchar] (50) NOT NULL,
[RegularExpression] [varchar] (255) NOT NULL,
[ComplexRule] [varchar] (2048) NOT NULL,
[DefaultText] [varchar] (255) NOT NULL,
[LabelText] [varchar] (255) NOT NULL,
[ToolTip] [varchar] (255) NOT NULL
) ON [PRIMARY]


