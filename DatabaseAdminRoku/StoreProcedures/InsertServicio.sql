CREATE PROCEDURE [dbo].[InsertServicio]
	
	@Descripcion varchar(50),
	@Costo decimal(18, 2),
	@Estado bit,
	@FechaCreacion datetime
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO [Servicios] ( Descripcion,Costo,Estado,FechaCreacion) 
	Values (@Descripcion,@Costo,@Estado,@FechaCreacion)
END