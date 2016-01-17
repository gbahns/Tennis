CREATE PROCEDURE dbo.csla_get_business_rules
	@ClassName varchar(200)
AS
	select 
		FieldName,
		Required,
		MinValue,
		MaxValue,
		Mask,
		RegularExpression,
		ComplexRule,
		DefaultText,
		LabelText,
		Tooltip
	from
		BusinessRules
	where
		ClassName = @ClassName


