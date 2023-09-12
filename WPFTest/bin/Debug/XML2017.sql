/*
Navicat SQL Server Data Transfer

Source Server         : mssql-localhost
Source Server Version : 110000
Source Host           : 127.0.0.1:1433
Source Database       : XML2017
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2018-10-11 21:56:08
*/



-- ----------------------------
-- Table structure for myBook
-- ----------------------------
DROP TABLE [dbo].[myBook]
GO
CREATE TABLE [dbo].[myBook] (
[year] int NULL ,
[title] varchar(100) NULL ,
[price] float(53) NULL ,
[author_first] varchar(100) NULL ,
[author_last] varchar(100) NULL ,
[publisher] varchar(100) NULL ,
[id] varchar(36) NOT NULL 
)


GO

-- ----------------------------
-- Records of myBook
-- ----------------------------
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'1994', N'TCP/IP Illustrated', N'300', N'Stevens', N'W.', N'Addison-Wesley', N'1')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'1992', N'Advanced Programming in the Unix environment', N'200', N'Stevens', N'W.', N'Addison-Wesley', N'2')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'0', N'b', N'10', N'b', N'a', N'a', N'2018083116075245755999')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'0', N'a', N'0', N'a', N'a', N'a', N'2018083116244252844547')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'2000', N'Data on the Web', N'39.95', N'Abiteboul', N'Serge', N'Morgan Kaufmann Publishers', N'3')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'1999', N'The Economics of Technology and Content for Digital TV', N'129.95', N'test', N'test', N'Kluwer Academic Publishers', N'4')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'1994', N'TCP/IP Illustrated', N'65.95', N'Stevens', N'W.', N'Addison-Wesley', N'5')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'1992', N'Advanced Programming in the Unix environment', N'65.95', N'Stevens', N'W.', N'Addison-Wesley', N'6')
GO
GO
INSERT INTO [dbo].[myBook] ([year], [title], [price], [author_first], [author_last], [publisher], [id]) VALUES (N'2000', N'Data on the Web', N'39.95', N'Abiteboul', N'Serge', N'Morgan Kaufmann Publishers', N'7')
GO
GO



-- ----------------------------
-- Indexes structure for table myBook
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table myBook
-- ----------------------------
ALTER TABLE [dbo].[myBook] ADD PRIMARY KEY ([id])
GO