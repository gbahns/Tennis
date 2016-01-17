CREATE PROCEDURE [dbo].[csla_get_user]
	@uid varchar(20)
AS

SET NOCOUNT ON

select
	id, 
	email
from 
	Users 
where 
	uid=@uid
	
select
	r.Name
from
	users u
	join UserRoles ur on ur.UserID = u.id
	join Roles r on r.id = ur.RoleID
where
	u.uid=@uid


