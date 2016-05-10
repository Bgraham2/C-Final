USE [final]
GO

/****** Object:  StoredProcedure [dbo].[usp_get_patron]    Script Date: 12/08/2015 11:48:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_get_patron]

@p_id					bigint = NULL
, @p_patron_type_id		bigint = NULL
, @p_first_name			varchar(50) = NULL
, @p_last_name			varchar(50) = NULL
, @p_username			varchar(50) = NULL
, @p_password			varchar(100) = NULL

AS
BEGIN
/*


exec usp_get_patron NULL, NULL, '', '', '', ''

*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT	id, patron_type_id, first_name, last_name, username, password, phone, email, active, date_created, date_modified
	FROM	dbo.patron
	WHERE	id					 = ISNULL(@p_id, id)
	AND		patron_type_id		 = ISNULL(@p_patron_type_id, patron_type_id)
	AND		first_name			 LIKE '%' + @p_first_name + '%'
	AND		last_name			 LIKE '%' + @p_last_name + '%'
	AND		username			 LIKE '%' + @p_username + '%'
	AND		password			 LIKE '%' + @p_password + '%'
	
END



GO

