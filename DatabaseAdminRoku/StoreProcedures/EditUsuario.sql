CREATE PROCEDURE [dbo].[EditUsuario]
	-- Add the parameters for the stored procedure here
	@Id Int,
	@Nombre varchar(250),
	@Usuario varchar(50),
	@Contrasena varchar(50),
	@FechaMod Datetime,
	@Estado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuarios SET Nombre=@Nombre,Usuario=@Usuario,Contrasena =@Contrasena,Estado=@Estado, FechaModificacion= (GETDATE())
	 Where Id=@Id
END