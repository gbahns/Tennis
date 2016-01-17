CREATE PROCEDURE [dbo].csla_changepassword
	@uid varchar(20),
	@pwd varchar(20),
	@newpwd varchar(20)
AS

SET NOCOUNT ON

update Users
set pwd=@newpwd
where uid=@uid and pwd=@pwd

select @@rowcount RowsAffected
--return @@rowcount


