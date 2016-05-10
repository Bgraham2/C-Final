USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_save_author]    Script Date: 12/08/2015 11:49:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_save_author]

@p_id					bigint = NULL OUTPUT,
 @p_name				varchar(50) = NULL,
 @p_address				varchar(50) = NULL,
 @p_phone				varchar(50) = NULL,
 @p_email				varchar(50) = NULL,
 @p_debug				int = NULL

AS
BEGIN
/*

DECLARE @v_id BIGINT

SET @v_id = NULL
exec usp_save_author @v_id OUTPUT, 'Stephen King', '234 Maine', '913-555-1212', 'email@email.com', 1
PRINT '@v_id = ' + CAST(@v_id AS VARCHAR)



*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @p_debug = 1
	BEGIN
		PRINT 'THIS IS A DEBUG LINE...'
		PRINT '@p_id = ' + CAST(@p_id AS VARCHAR)
		PRINT '@p_name = ' + @p_name
		PRINT '@p_adress = ' + @p_address
		PRINT '@p_phone = ' + @p_phone
		PRINT '@p_email = ' + @p_email
	END
	
	IF @p_name IS NULL OR 
		@p_address IS NULL 

		
	BEGIN
		RAISERROR ('A REQUIRED PARAMETER IS MISSING', 16, 0)
		RETURN -1
	END
	
	IF @p_id IS NULL OR @p_id <= 0
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS NULL -- DOING A INSERT'
		END
		INSERT INTO dbo.author
		(name, address, phone, email, date_created, date_modified)
		VALUES
		(@p_name, @p_address, @p_phone, @p_email, GETDATE(), GETDATE())
		
		SELECT @p_id = @@IDENTITY;
		
	END
	ELSE
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS VALID -- DOING AN UPDATE'
		END
		
		UPDATE dbo.author
		SET 
			name = @p_name
		,	address = @p_address
		,	phone = @p_phone
		,	email = @p_email
		,	date_modified = GETDATE()
		WHERE id = @p_id
		
	END

END



GO

