create PROCEDURE csla_get_password
	@uid varchar(20)
AS

SET NOCOUNT ON

select
	pwd
from 
	Users
where 
	uid=@uid


