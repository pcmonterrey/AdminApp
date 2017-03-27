CREATE PROCEDURE [dbo].[GetUsuarios]
	-- Add the parameters for the stored procedure here
	
	@Estatus bit
AS
BEGIN
	SET NOCOUNT ON;
	Select Id,Nombre,Usuario,Contrasena,Estado,FechaCreacion,FechaModificacion from Usuarios --Where Estado = null
END