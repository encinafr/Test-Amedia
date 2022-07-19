--11) Ver películas que no fueron devueltas y que usuarios la tienen
CREATE PROCEDURE [dbo].[UnreturnedMovies]
AS
BEGIN

	BEGIN

		 SELECT 
			  P.txt_desc as Movie_Name,
			  U.txt_nombre + U.txt_apellido as User_FullName
		  FROM [dbo].[tPelicula] as P
		  Join tAlquilerPelicula  as AP on P.cod_pelicula = AP.cod_pelicula 
		  Join tUsers  as U on Ap.cod_usuario = U.cod_usuario
		  Where AP.fecha_devolucion is null

	END

END
GO

--Exec UnreturnedMovies

