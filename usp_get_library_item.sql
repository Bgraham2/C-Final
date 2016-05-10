USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_library_item]    Script Date: 12/08/2015 11:47:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_library_item]

@p_id					bigint = NULL
, @p_item_type_id		bigint = NULL
, @p_publisher_id		bigint = NULL
, @p_author_id			bigint = NULL
, @p_title				varchar(100) = NULL
, @p_isbn				varchar(50) = NULL


AS
BEGIN
/*

exec usp_get_library_item NULL, NULL, NULL, NULL, '', ''

*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	id, item_type_id, publisher_id, author_id, title, isbn, date_created, date_modified
	FROM	dbo.library_item
	WHERE	id					 = ISNULL(@p_id, id)
	AND		item_type_id		 = ISNULL(@p_item_type_id, item_type_id)
	AND		publisher_id		 = ISNULL(@p_publisher_id, publisher_id)
	AND		author_id			 = ISNULL(@p_author_id, author_id)
	AND		title				 LIKE '%' + @p_title + '%'
	AND		isbn				 LIKE '%' + @p_isbn + '%'

END



GO

