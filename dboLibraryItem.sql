USE [final]
GO

/****** Object:  Table [dbo].[library_item]    Script Date: 12/08/2015 11:46:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[library_item](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[item_type_id] [bigint] NOT NULL,
	[publisher_id] [bigint] NOT NULL,
	[author_id] [bigint] NOT NULL,
	[title] [varchar](100) NOT NULL,
	[isbn] [varchar](50) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
 CONSTRAINT [PK_library_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[library_item] ADD  CONSTRAINT [DF_library_item_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[library_item] ADD  CONSTRAINT [DF_library_item_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

