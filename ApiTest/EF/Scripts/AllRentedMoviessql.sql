--13) Ver todas las películas, cuantas veces fueron alquiladas y cuanto se recaudo por
--ellas


CREATE PROCEDURE [dbo].[AllRentedMovies]

AS
BEGIN

	BEGIN

		 SELECT 
			  P.txt_desc as Movie_Name,
			  COUNT(AP.cod_alquiler) as Cantidad_Alquiladas,
			  COUNT(AP.cod_alquiler) * AP.precio as Recaudacion
		  FROM [dbo].[tPelicula] as P
		  Join tAlquilerPelicula  as AP on P.cod_pelicula = AP.cod_pelicula 
		  Join tUsers  as U on Ap.cod_usuario = U.cod_usuario
		  GROUP BY P.txt_desc, Ap.precio ;

	END

END
GO
