CREATE PROCEDURE csla_confirm_new_user
	@id int,
	@uid varchar(20),
	@email varchar(50)
AS

SET NOCOUNT ON

update Users
set approved = 1
where id = @id
and uid = @uid
and email = @email	

select @@rowcount RowsAffected


