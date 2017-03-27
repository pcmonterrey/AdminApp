CREATE TABLE [dbo].[UsuariosServicios](
	[IdServicio] [int] NOT NULL,
	[IdUsario] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[FechaInicioServicio] [datetime] NOT NULL,
	[FechaFinServicio] [datetime] NOT NULL,
	[NumeroCreditos] [smallint] NOT NULL,
 CONSTRAINT [PK_UsuariosServicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]