USE [BDGestionNegocio]
GO
/****** Object:  StoredProcedure [dbo].[spr_GetListAllTaxesXProduct]    Script Date: 27/12/2017 10:32:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 25/07/2017
-- Description:	Get Taxes By Product
-- =============================================
ALTER PROCEDURE [dbo].[spr_GetListAllTaxesXProduct]
	@IdProduct as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select Ta.IdTax, Ta.IsPercent, Ta.NameTax, Ta.ValueTax,Ta.CreationDate, Ta.IdStatus, St.IdStatus, st.DsEstado,
	Ob.IdObject, Ob.NameObject
	From TaxesXProduct Tp
	Inner Join Product Pr On Pr.IdProduct = Tp.IdProduct
	Inner Join Taxes Ta On Ta.IdTax = Tp.IdTax
	Inner Join [Object] Ob On Ob.IdObject = Ta.IdObject
	Inner Join [Status] St On St.IdStatus = Ta.IdStatus AND St.IdObject = Ob.IdObject
	Where Pr.IdProduct = @IdProduct

END
