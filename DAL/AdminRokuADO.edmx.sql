
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/17/2017 21:12:04
-- Generated from EDMX file: C:\Users\Roberto\Source\Repos\AdminApp\DAL\AdminRokuADO.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdminRoku];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuariosServicios_Servicios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosServicios] DROP CONSTRAINT [FK_UsuariosServicios_Servicios];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuariosServicios_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuariosServicios] DROP CONSTRAINT [FK_UsuariosServicios_Usuarios];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Servicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[UsuariosServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuariosServicios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Servicios'
CREATE TABLE [dbo].[Servicios] (
    [Descripcion] varchar(50)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Costo] decimal(18,2)  NOT NULL,
    [Estado] bit  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(250)  NOT NULL,
    [Usuario] varchar(50)  NOT NULL,
    [Contrasena] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaModificacion] datetime  NULL
);
GO

-- Creating table 'UsuariosServicios'
CREATE TABLE [dbo].[UsuariosServicios] (
    [IdServicio] int  NOT NULL,
    [IdUsario] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Estado] bit  NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [FechaModificacion] datetime  NULL,
    [FechaInicioServicio] datetime  NOT NULL,
    [FechaFinServicio] datetime  NOT NULL,
    [NumeroCreditos] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [PK_Servicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuariosServicios'
ALTER TABLE [dbo].[UsuariosServicios]
ADD CONSTRAINT [PK_UsuariosServicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdServicio] in table 'UsuariosServicios'
ALTER TABLE [dbo].[UsuariosServicios]
ADD CONSTRAINT [FK_UsuariosServicios_Servicios]
    FOREIGN KEY ([IdServicio])
    REFERENCES [dbo].[Servicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosServicios_Servicios'
CREATE INDEX [IX_FK_UsuariosServicios_Servicios]
ON [dbo].[UsuariosServicios]
    ([IdServicio]);
GO

-- Creating foreign key on [IdUsario] in table 'UsuariosServicios'
ALTER TABLE [dbo].[UsuariosServicios]
ADD CONSTRAINT [FK_UsuariosServicios_Usuarios]
    FOREIGN KEY ([IdUsario])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosServicios_Usuarios'
CREATE INDEX [IX_FK_UsuariosServicios_Usuarios]
ON [dbo].[UsuariosServicios]
    ([IdUsario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------