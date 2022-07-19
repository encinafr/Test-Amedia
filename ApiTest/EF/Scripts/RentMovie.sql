CREATE PROCEDURE [dbo].[RentMovie]
		@cod_pelicula int,
		@cod_usuario int,
		@fecha_devolucion date,
		@fecha_estipulada_devoluvion date
AS
BEGIN
    
	IF EXISTS (SELECT * FROM tPelicula
                   WHERE cod_pelicula = @cod_pelicula)


	BEGIN
	   --Se considera que solo se alquila una pelicula por cliente
	    DECLARE @cant_disponible int;
		SET @cant_disponible = (SELECT cant_disponibles_alquiler from tPelicula where cod_pelicula = @cod_pelicula);
		
		IF @cant_disponible > 0

		    UPDATE tPelicula
		    set cant_disponibles_alquiler = cant_disponibles_alquiler - 1
			where cod_pelicula = @cod_pelicula;

			INSERT INTO [dbo].[tAlquilerPelicula]
					   ([cod_usuario]
					   ,[cod_pelicula]
					   ,[precio]
					   ,[fecha_alquiler]
					   ,[fecha_devolucion]
					   ,[fecha_estipulada_devoluvion])
			SELECT  @cod_usuario,
					@cod_pelicula,
					precio_alquiler,
					GETDATE(),
					@fecha_devolucion,
					@fecha_estipulada_devoluvion
			FROM [dbo].[tPelicula] 
			where cod_pelicula = @cod_pelicula
				  
	END

END
GO
