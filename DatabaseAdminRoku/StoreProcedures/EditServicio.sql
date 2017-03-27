Create PROCEDURE [dbo].[EditServicio]
	@Descripcion varchar(50),
	@Costo decimal(18,2),
	@Estado bit,
	@Id int
	
AS
BEGIN
	SET NOCOUNT ON;

	Update Servicios Set Descripcion=@Descripcion,Costo=@Costo,Estado=@Estado,FechaModificacion=(GETDATE()) 
	Where Id= @Id
END