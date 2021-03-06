
/****** Object:  StoredProcedure [dbo].[spr_CreateProduct]    Script Date: 11/12/2017 11:07:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Create Product
-- =============================================
ALTER PROCEDURE [dbo].[spr_CreateProduct]
	@NameProduct as varchar(50),
	@CdProduct as varchar(100),
	@IdUnit as int,
	@Price as Numeric(18,4),
	@IdSupplier as int,
	@PriceSupplier as Numeric(18,4),
	@IdObject as Int,
	@IdStatus as varchar(10)
AS
BEGIN

	SET NOCOUNT ON;

	Insert Into Product(NameProduct, CdProduct, CreationDate, IdUnit, Price, IdSupplier, PriceSupplier, IdObject, IdStatus)
	Values(@NameProduct, @CdProduct, GETDATE(), @IdUnit, @Price, @IdSupplier, @PriceSupplier, @IdObject, @IdStatus) 

END
