
/****** Object:  StoredProcedure [dbo].[spr_CreateProduct]    Script Date: 15/03/2017 04:55:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Update Product By Id
-- =============================================
CREATE PROCEDURE [dbo].[spr_UpdateSupplier]
	@IdSupplier as int,
	@NameSupplier as varchar(50),
	@IdTypeIdentification as int,
	@NoIdentification as varchar(20),
	@IdStatus as int,
	@IdObject as int
AS
BEGIN

	SET NOCOUNT ON;

	Update Supplier Set NameSupplier = @NameSupplier,IdTypeIdentification = @IdTypeIdentification, 
	NoIdentification = @NoIdentification,  IdStatus = @IdStatus, IdObject = @IdObject
	Where IdSupplier = @IdSupplier

END
