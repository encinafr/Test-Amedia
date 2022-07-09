USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 7/8/2022 9:28:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

--Crear usuarios, cuyo documento no exista actualmente en la base de datos, en
--caso de existir, debería devolver un mensaje de error, en caso contrario insertarlo
CREATE PROCEDURE [dbo].[CreateUser]
		@txt_user varchar(50),
		@txt_password varchar(50),
		@txt_nombre varchar(200),
		@txt_apellido varchar(200),
		@nro_doc varchar(50),
		@cod_rol int,
		@sn_activo int,
		@new_identity INT = NULL OUTPUT
AS
BEGIN

	IF NOT EXISTS ( SELECT * FROM tUsers
                   WHERE nro_doc = @nro_doc )
	BEGIN
	INSERT INTO [dbo].[tUsers]
			   ([txt_user]
			   ,[txt_password]
			   ,[txt_nombre]
			   ,[txt_apellido]
			   ,[nro_doc]
			   ,[cod_rol]
			   ,[sn_activo])
		 VALUES
			   (@txt_user
			   ,@txt_password
			   ,@txt_nombre
			   ,@txt_apellido
			   ,@nro_doc
			   ,@cod_rol
			   ,@sn_activo)
			   END

	SET @new_identity = SCOPE_IDENTITY();

	
END
GO


