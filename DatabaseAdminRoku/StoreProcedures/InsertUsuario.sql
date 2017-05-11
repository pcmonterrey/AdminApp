Create PROCEDURE [dbo].[InsertUsuario]
	-- Add the parameters for the stored procedure here
	
	@Nombre  varchar(250), 
	@Usuario varchar(50),
	@Contrasena varchar(50),
	@Estado bit,
	@FechaCreacion datetime
	
AS
BEGIN
	Insert into [Usuarios](Nombre,Usuario,Contrasena,Estado,FechaCreacion) 
	Values (@Nombre,@Usuario,@Contrasena,@Estado,@FechaCreacion)
END