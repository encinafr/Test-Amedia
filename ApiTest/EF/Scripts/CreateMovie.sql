

CREATE PROCEDURE [dbo].[CreateMovie]
		@txt_desc varchar(500),
		@cant_disponibles_alquiler int,
		@cant_disponibles_venta int,
		@precio_alquiler numeric(18,2),
		@precio_venta numeric(18,2),
		@new_identity INT = NULL OUTPUT
AS
BEGIN

	IF NOT EXISTS ( SELECT * FROM tPelicula
                   WHERE txt_desc = @txt_desc )
	BEGIN
	INSERT INTO [dbo].[tPelicula]
           ([txt_desc]
           ,[cant_disponibles_alquiler]
           ,[cant_disponibles_venta]
           ,[precio_alquiler]
           ,[precio_venta])
     VALUES
           (@txt_desc,
		    @cant_disponibles_alquiler,
		    @cant_disponibles_venta,
			@precio_alquiler,
			@precio_venta)
	 END

	SET @new_identity = SCOPE_IDENTITY();

	
END
GO

--DECLARE @new_identity int;

--Exec [dbo].[CreateMovie] 'Mentiroso mentiroso', 2, 1, 2.00, 6.00, @new_identity;




