
/****** Object:  StoredProcedure [dbo].[spr_GetUserByIdUser]    Script Date: 24/01/2018 15:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 22-01-2018	
-- Description:	Traer Usuario por Id Usuario
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetUserByIdUser]
	@IdUser as int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT u.IdUser, u.NoIdentification, u.FName, u.SName, u.FLastName, u.SLastName, 
	u.Usuario, u.[Password] as PasswordHash, r.NameRole, Ob.IdObject, St.IdStatus, U.Email
	From [User] u
	Inner Join UserRole ur On ur.IdUser = u.IdUser
	Inner Join [Role] r On ur.IdRole = r.IdRole
	Inner Join [Object] Ob On Ob.IdObject = u.IdObject
	Inner Join [Status] St On St.IdStatus = u.IdStatus And St.IdObject = Ob.IdObjecT
	Where U.IdUser = @IdUser 
END
