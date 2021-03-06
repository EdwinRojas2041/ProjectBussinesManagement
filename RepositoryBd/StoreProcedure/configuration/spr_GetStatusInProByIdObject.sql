/****** Object:  StoredProcedure [dbo].[spr_GetStatusApproByIdObject]    Script Date: 27/04/2018 03:17:21 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 19-09-2017
-- Description:	Procedimiento almacenado cque trae el status en progreso
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetStatusInProByIdObject]
	@IdObject as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Select s.IdStatus, o.IdObject, o.NameObject, s.NameStatus, s.DsEstado, s.CreationDate, s.flActive, s.ModificationDate  
	From [Status] s
	iNNER jOIN [Object] o On o.IdObject = s.IdObject
	where s.IdObject = @IdObject and IdStatus = 'INPRO'
END
