
USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[CreateGenre]    Script Date: 7/8/2022 9:28:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateGenre]
		@txt_desc varchar(500),
		@new_identity INT = NULL OUTPUT
AS
BEGIN

	IF NOT EXISTS ( SELECT * FROM tGenero
                   WHERE txt_desc = @txt_desc)
	BEGIN

		 INSERT INTO [dbo].[tGenero]
			   ([txt_desc])
		 VALUES
			   (@txt_desc);


		SET @new_identity = SCOPE_IDENTITY();
	END

END
GO