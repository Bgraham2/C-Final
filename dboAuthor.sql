USE [final]
GO

/****** Object:  Table [dbo].[author]    Script Date: 12/08/2015 11:45:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[author](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](100) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[author] ADD  CONSTRAINT [DF_author_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[author] ADD  CONSTRAINT [DF_author_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

