USE [db06]
GO

/****** Object:  StoredProcedure [dbo].[usp_edit_patron]    Script Date: 12/10/2015 17:59:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_edit_patron]

@p_id					bigint = NULL OUTPUT,
@p_patron_type_id		bigint = NULL OUTPUT,
 @p_first_name			varchar(50) = NULL,
 @p_last_name			varchar(50) = NULL,
 @p_username			varchar(50) = NULL,
 @p_password			varchar(100) = NULL,
 @p_phone				varchar(50) = NULL,
 @p_email				varchar(50) = NULL,
 @p_active				bit = NULL,
 @p_debug				int = NULL

AS
BEGIN
/*

DECLARE @v_id BIGINT

SET @v_id = NULL
exec usp_save_patron @v_id OUTPUT, 1, 'Brian', 'Graham', 'bgraham', 'password', '913-555-1212', 'email@email.com', 1, 1
PRINT '@v_id = ' + CAST(@v_id AS VARCHAR)



*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @p_debug = 1
	BEGIN
		PRINT 'THIS IS A DEBUG LINE...'
		PRINT '@p_id = ' + CAST(@p_id AS VARCHAR)
		PRINT '@p_first_name = ' + @p_first_name
		PRINT '@p_last_name = ' + @p_last_name
		PRINT '@p_username= ' + @p_username
		PRINT '@p_password = ' + @p_password
		PRINT '@p_phone = ' + @p_phone
		PRINT '@p_email = ' + @p_email
		PRINT '@p_active = ' + CAST(@p_active AS VARCHAR)
	END
	
	IF @p_first_name IS NULL OR 
		@p_last_name IS NULL OR
		@p_username IS NULL OR
		@p_password IS NULL  
		
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
		INSERT INTO dbo.patron
		(patron_type_id, first_name, last_name, username, password, phone, email, active, date_created, date_modified)
		VALUES
		(@p_patron_type_id, @p_first_name, @p_last_name, @p_username, @p_password, @p_phone, @p_email, @p_active, GETDATE(), GETDATE())
		
		SELECT @p_id = @@IDENTITY;
		
	END
	ELSE
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS VALID -- DOING AN UPDATE'
		END
		
		UPDATE dbo.patron
		SET 
			patron_type_id = @p_patron_type_id
		,	first_name = @p_first_name
		,	last_name = @p_last_name
		,	username = @p_username
		,	password = @p_password
		,	phone = @p_phone
		,	email = @p_email
		,   active = @p_active
		,	date_modified = GETDATE()
		WHERE id = @p_id
		
	END

END






GO

