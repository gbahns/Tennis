CREATE PROCEDURE [dbo].[csla_login]
	(
		@uid varchar(20),
		@pwd varchar(20)
	)
AS
	SET NOCOUNT ON
	
	select 
		playerid, 
		isnull(Players.FirstName + ' ' + Players.LastName,'GUEST') Name 
	from 
		Users
		LEFT OUTER JOIN Players ON Users.playerid = Players.ID
	where 
		uid=@uid and pwd=@pwd and approved=1
		
	select
		r.Name
	from
		users u
		join UserRoles ur on ur.UserID = u.id
		join Roles r on r.id = ur.RoleID
	where
		u.uid=@uid and u.pwd=@pwd


