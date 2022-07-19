USE [Test]
GO


CREATE PROCEDURE [dbo].[UpdateMovie]
		@txt_desc varchar(500),
		@cant_disponibles_alquiler int,
		@cant_disponibles_venta int,
		@precio_alquiler numeric(18,2),
		@precio_venta numeric(18,2)
AS
BEGIN

	BEGIN

	UPDATE [dbo].[tPelicula]
    SET [txt_desc] = @txt_desc
      ,[cant_disponibles_alquiler] = @cant_disponibles_alquiler
      ,[cant_disponibles_venta] = @cant_disponibles_venta
      ,[precio_alquiler] = @precio_alquiler
      ,[precio_venta] = @precio_venta
	WHERE txt_desc = @txt_desc;

	END

END
GO

