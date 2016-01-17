CREATE procedure [dbo].[csla_create_user]
	@id int output,
	@uid varchar(20),
	@pwd varchar(20),
	@email varchar(50),
	@approved bit
AS

SET NOCOUNT ON

insert Users values (@uid,@pwd,null,@email,@approved)

set @id = @@identity


