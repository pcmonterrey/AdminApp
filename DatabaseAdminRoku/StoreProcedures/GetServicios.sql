CREATE PROCEDURE [dbo].[GetServicios]
	@Estatus bit 
AS
BEGIN
	SET NOCOUNT ON;
	Select Id,Descripcion,Costo,Estado,FechaCreacion,FechaModificacion from Servicios
END