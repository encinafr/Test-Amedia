--12) Ver qué películas fueron alquiladas por usuario y cuánto pagó y que día
CREATE PROCEDURE [dbo].[RentedMovies]
@cod_usuario int
AS
BEGIN

	BEGIN

		 SELECT 
			  P.txt_desc as Movie_Name,
			  U.txt_nombre + U.txt_apellido as User_FullName,
			  P.precio_alquiler as Precio_Alquiler,
			  Ap.fecha_alquiler as Fecha_Alquiler
		  FROM [dbo].[tPelicula] as P
		  Join tAlquilerPelicula  as AP on P.cod_pelicula = AP.cod_pelicula 
		  Join tUsers  as U on Ap.cod_usuario = U.cod_usuario
		  Where Ap.cod_usuario = @cod_usuario

	END

END
GO

--Exec RentedMovies 1