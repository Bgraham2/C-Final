USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_publisher]    Script Date: 12/08/2015 11:49:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_publisher]

@p_id					bigint = NULL
, @p_name				varchar(50) = NULL
, @p_address			varchar(100) = NULL
, @p_phone				varchar(50) = NULL
, @p_email				varchar(100) = NULL

AS
BEGIN
/*

exec usp_get_publisher NULL, '', '', '', ''

*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	id, name, address, phone, email, date_created, date_modified
	FROM	dbo.publisher
	WHERE	id					 = ISNULL(@p_id, id)
	AND		name				LIKE '%' + @p_name + '%'
	AND		address				LIKE '%' + @p_address + '%'
	AND		phone			    LIKE '%' + @p_phone + '%'
	AND		email			    LIKE '%' + @p_email + '%'
	
END



GO

