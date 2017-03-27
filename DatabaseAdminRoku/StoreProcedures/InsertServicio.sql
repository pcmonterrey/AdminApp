CREATE PROCEDURE [dbo].[InsertServicio]
	
	@Descripcion varchar(50),
	@Costo decimal(18, 2)
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO [Servicios] ( Descripcion,Costo) 
	Values (@Descripcion,@Costo)
END