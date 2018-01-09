 QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 09-01-2018	
-- Description:	Traer Usuario por usuario y password
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetUserByUser]
	@User as varchar(100),
	@Password as varchar(MAX) 
AS
BEGIN

	SET NOCOUNT ON;

	SELECT u.IdUser, u.NoIdentification, u.FName, u.SName, u.Usuario, r.NameRole, Ob.IdObject, St.IdStatus
	From [User] u
	Inner Join UserRole ur On ur.IdUser = u.IdUser
	Inner Join [Role] r On ur.IdRole = r.IdRole
	Inner Join [Object] Ob On Ob.IdObject = u.IdObject
	Inner Join [Status] St On St.IdStatus = u.IdStatus And St.IdObject = Ob.IdObjecT
	Where U.Usuario = @User And u.[Password] = @Password
END
