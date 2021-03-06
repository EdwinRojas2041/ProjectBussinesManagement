
/****** Object:  StoredProcedure [dbo].[spr_GetParameterConfigurationActive]    Script Date: 02/02/2018 11:45:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 01-10-2017
-- Description:	Traer Valor de la configuracion
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetParameterConfigurationActive]
	@NameParameter as varchar(50),
	@flActive as tinyint
AS
BEGIN

	SET NOCOUNT ON;

	Select IdParameter, 'True' as Value, GETDATE() as CreationDate
	From ParameterConfiguration pc
	Where pc.NameParameter = @NameParameter and
	pc.flActive = @flActive
END
