/****** Script for SelectTopNRows command from SSMS  ******/

 CREATE PROCEDURE [dbo].[AddMovioeGenre]
		@cod_pelicula int,
		@cod_genero int
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM tGeneroPelicula
                   WHERE cod_pelicula = @cod_pelicula)
	BEGIN
	 INSERT INTO tGeneroPelicula VALUES(@cod_pelicula, @cod_genero)
	END

END
GO