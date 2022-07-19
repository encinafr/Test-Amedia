CREATE PROCEDURE [dbo].[SellMovie]
		@cod_pelicula int,
		@cod_usuario int
AS
BEGIN
    
	IF EXISTS (SELECT * FROM tPelicula
                   WHERE cod_pelicula = @cod_pelicula)


	BEGIN
	   --Se considera que solo se alquila una pelicula por cliente
	    DECLARE @cant_disponible int;
		SET @cant_disponible = (SELECT cant_disponibles_venta from tPelicula where cod_pelicula = @cod_pelicula);
		
		IF @cant_disponible > 0

		    UPDATE tPelicula
		    set cant_disponibles_venta = cant_disponibles_venta - 1
			where cod_pelicula = @cod_pelicula;

			INSERT INTO [dbo].[tVentaPelicula]
					   ([cod_usuario]
					   ,[cod_pelicula]
					   ,[precio]
					   ,[fecha_venta])
			SELECT  @cod_usuario,
					@cod_pelicula,
					precio_venta,
					GETDATE()
			FROM [dbo].[tPelicula] 
			where cod_pelicula = @cod_pelicula
				  
	END

END
GO



USE [Test]
GO

SELECT [cod_venta]
      ,[cod_usuario]
      ,[cod_pelicula]
      ,[precio]
      ,[fecha_venta]
  FROM [dbo].[tVentaPelicula]

GO

