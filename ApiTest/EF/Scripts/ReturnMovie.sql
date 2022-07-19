CREATE PROCEDURE [dbo].[ReturnMovie]
		@cod_pelicula int,
		@cod_usuario int
AS
BEGIN
    
	IF EXISTS (SELECT * FROM tPelicula
                   WHERE cod_pelicula = @cod_pelicula)


	BEGIN
		    UPDATE tPelicula
		    set cant_disponibles_alquiler = cant_disponibles_alquiler + 1
			where cod_pelicula = @cod_pelicula;

			UPDATE [dbo].[tAlquilerPelicula]
		    set fecha_devolucion = GETDATE()
			where cod_pelicula = @cod_pelicula and cod_usuario = @cod_usuario
				  
	END

END
GO

--Exec ReturnMovie 3, 2