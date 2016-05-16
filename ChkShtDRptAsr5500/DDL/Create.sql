USE [dev]
GO

/****** Object:  Table [dbo].[asr5500_chksheets]    Script Date: 05/16/2016 17:26:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[asr5500_chksheets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[no1] [bit] NULL,
	[no2] [bit] NULL,
	[no3] [bit] NULL,
	[no4] [bit] NULL,
	[no5] [bit] NULL,
	[no6] [bit] NULL,
	[no7] [bit] NULL,
	[no8] [bit] NULL,
	[no9] [bit] NULL,
	[no10] [bit] NULL,
	[no11] [bit] NULL,
	[no12] [bit] NULL,
	[no13] [bit] NULL,
	[no14] [bit] NULL,
	[no15] [bit] NULL,
	[no16] [bit] NULL,
	[no17] [bit] NULL,
	[no18] [bit] NULL,
	[no19] [bit] NULL,
	[no20] [bit] NULL,
	[no21] [bit] NULL,
	[no22] [bit] NULL,
	[no23] [bit] NULL,
	[no24] [bit] NULL,
	[no25] [bit] NULL,
	[no26] [bit] NULL,
	[no27] [bit] NULL,
	[no28] [bit] NULL,
	[no29] [bit] NULL,
	[no30] [bit] NULL,
	[no31] [bit] NULL,
	[no32] [bit] NULL,
	[no33] [bit] NULL,
	[no34] [bit] NULL,
	[no35] [bit] NULL,
	[no36] [bit] NULL,
	[no37] [bit] NULL,
	[no38] [bit] NULL,
	[no39] [bit] NULL,
	[no40] [bit] NULL,
	[no1_dblchk] [bit] NULL,
	[no2_dblchk] [bit] NULL,
	[no3_dblchk] [bit] NULL,
	[no4_dblchk] [bit] NULL,
	[no5_dblchk] [bit] NULL,
	[no6_dblchk] [bit] NULL,
	[no7_dblchk] [bit] NULL,
	[no8_dblchk] [bit] NULL,
	[no9_dblchk] [bit] NULL,
	[no10_dblchk] [bit] NULL,
	[no11_dblchk] [bit] NULL,
	[no12_dblchk] [bit] NULL,
	[no13_dblchk] [bit] NULL,
	[no14_dblchk] [bit] NULL,
	[no15_dblchk] [bit] NULL,
	[no16_dblchk] [bit] NULL,
	[no17_dblchk] [bit] NULL,
	[no18_dblchk] [bit] NULL,
	[no19_dblchk] [bit] NULL,
	[no20_dblchk] [bit] NULL,
	[no21_dblchk] [bit] NULL,
	[no22_dblchk] [bit] NULL,
	[no23_dblchk] [bit] NULL,
	[no24_dblchk] [bit] NULL,
	[no25_dblchk] [bit] NULL,
	[no26_dblchk] [bit] NULL,
	[no27_dblchk] [bit] NULL,
	[no28_dblchk] [bit] NULL,
	[no29_dblchk] [bit] NULL,
	[no30_dblchk] [bit] NULL,
	[no31_dblchk] [bit] NULL,
	[no32_dblchk] [bit] NULL,
	[no33_dblchk] [bit] NULL,
	[no34_dblchk] [bit] NULL,
	[no35_dblchk] [bit] NULL,
	[no36_dblchk] [bit] NULL,
	[no37_dblchk] [bit] NULL,
	[no38_dblchk] [bit] NULL,
	[no39_dblchk] [bit] NULL,
	[no40_dblchk] [bit] NULL,
	[name1] [varchar](50) NULL,
	[name2] [varchar](50) NULL,
 CONSTRAINT [PK_asr5500_chksheets] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


