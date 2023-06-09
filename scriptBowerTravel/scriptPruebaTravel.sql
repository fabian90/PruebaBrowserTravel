USE [biblioteca]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 20/03/2023 1:53:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[apellidos] [varchar](45) NULL,
 CONSTRAINT [PK_autores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autoreshaslibros]    Script Date: 20/03/2023 1:53:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autoreshaslibros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[autores_id] [int] NOT NULL,
	[libros_ISBN] [bigint] NOT NULL,
 CONSTRAINT [PK_autores_has_libros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editoriales]    Script Date: 20/03/2023 1:53:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editoriales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[sede] [varchar](45) NULL,
 CONSTRAINT [PK_editoriales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 20/03/2023 1:53:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[ISBN] [bigint] IDENTITY(1,1) NOT NULL,
	[editoriales_id] [int] NULL,
	[titulo] [varchar](45) NULL,
	[sinopsis] [varchar](max) NULL,
	[n_paginas] [varchar](45) NULL,
 CONSTRAINT [PK_libros] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[autoreshaslibros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_autores] FOREIGN KEY([autores_id])
REFERENCES [dbo].[autores] ([id])
GO
ALTER TABLE [dbo].[autoreshaslibros] CHECK CONSTRAINT [FK_autores_has_libros_autores]
GO
ALTER TABLE [dbo].[autoreshaslibros]  WITH CHECK ADD  CONSTRAINT [FK_autores_has_libros_libros] FOREIGN KEY([libros_ISBN])
REFERENCES [dbo].[libros] ([ISBN])
GO
ALTER TABLE [dbo].[autoreshaslibros] CHECK CONSTRAINT [FK_autores_has_libros_libros]
GO
ALTER TABLE [dbo].[libros]  WITH CHECK ADD  CONSTRAINT [FK_libros_editoriales] FOREIGN KEY([editoriales_id])
REFERENCES [dbo].[editoriales] ([id])
GO
ALTER TABLE [dbo].[libros] CHECK CONSTRAINT [FK_libros_editoriales]
GO
