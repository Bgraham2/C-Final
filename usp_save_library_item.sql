USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_save_library_item]    Script Date: 12/08/2015 11:50:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_save_library_item]

@p_id					bigint = NULL OUTPUT,
@p_item_type_id			bigint = NULL OUTPUT,
@p_publisher_id			bigint = NULL OUTPUT,
@p_author_id			bigint = NULL OUTPUT,
 @p_title				varchar(100) = NULL,
 @p_isbn				varchar(50) = NULL,
 @p_debug				int = NULL

AS
BEGIN
/*

DECLARE @v_id BIGINT

SET @v_id = NULL
exec usp_save_library_item @v_id OUTPUT, 1, 1, 1, 'Carrie', '00-934592-88455-22', 1
PRINT '@v_id = ' + CAST(@v_id AS VARCHAR)



*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @p_debug = 1
	BEGIN
		PRINT 'THIS IS A DEBUG LINE...'
		PRINT '@p_id = ' + CAST(@p_id AS VARCHAR)
		PRINT '@p_item_type_id = ' + CAST(@p_item_type_id AS VARCHAR)
		PRINT '@p_publisher_id = ' + CAST(@p_publisher_id AS VARCHAR)
		PRINT '@p_author_id = ' + CAST(@p_author_id AS VARCHAR)
		PRINT '@p_title = ' + @p_title
		PRINT '@p_isbn = ' + @p_isbn
	END
	
	IF @p_title IS NULL OR 
		@p_isbn IS NULL 

		
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
		INSERT INTO dbo.library_item
		(item_type_id, publisher_id, author_id, title, isbn, date_created, date_modified)
		VALUES
		(@p_item_type_id, @p_publisher_id, @p_author_id, @p_title, @p_isbn, GETDATE(), GETDATE())
		
		SELECT @p_id = @@IDENTITY;
		
	END
	ELSE
	BEGIN
		IF @p_debug = 1
		BEGIN
			PRINT 'PRIMARY KEY IS VALID -- DOING AN UPDATE'
		END
		
		UPDATE dbo.library_item
		SET 
			item_type_id = @p_item_type_id
		,	publisher_id = @p_publisher_id
		,	author_id = @p_author_id
		,	title = @p_title
		,	isbn = @p_isbn
		,	date_modified = GETDATE()
		WHERE id = @p_id
		
	END

END




GO

