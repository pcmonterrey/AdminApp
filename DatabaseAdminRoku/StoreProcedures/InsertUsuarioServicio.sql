CREATE PROCEDURE [dbo].[InsertUsuarioServicio]
	@IdServicio int,
	@IdUsuario int,
	@Estado bit,
	@FechaCreacion datetime,
	@FechaInicioServicio datetime,
	@FechaFinServicio datetime,
	@NumerosCreditos int

AS
BEGIN
		SET NOCOUNT ON;
	insert into [UsuariosServicios] (IdServicio,IdUsario,Estado,FechaCreacion,FechaInicioServicio,FechaFinServicio,NumeroCreditos)
	values (@IdServicio,@IdUsuario,@Estado,@FechaCreacion,@FechaInicioServicio,@FechaFinServicio,@NumerosCreditos)
	
END
