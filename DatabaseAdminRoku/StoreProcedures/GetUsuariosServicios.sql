
CREATE PROCEDURE [dbo].[GetUsuariosServicios]
	@Estatus bit
AS
BEGIN
	SET NOCOUNT ON;
	Select UsuariosServicios.Id,Servicios.Descripcion as "DescripcionServicio" , Usuarios.Nombre as "NombreUsuario",UsuariosServicios.Estado,UsuariosServicios.FechaCreacion,UsuariosServicios.FechaModificacion,UsuariosServicios.FechaInicioServicio,UsuariosServicios.FechaFinServicio,UsuariosServicios.NumeroCreditos
	from UsuariosServicios --Where Estado = null
	INNER JOIN Usuarios ON Usuarios.id=UsuariosServicios.IdUsario
	INNER JOIN Servicios On Servicios.id = UsuariosServicios.IdServicio;
	
END