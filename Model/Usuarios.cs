
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Model
{

using System;
    using System.Collections.Generic;
    
public partial class Usuarios
{

    public Usuarios()
    {

        this.UsuariosServicios = new HashSet<UsuariosServicios>();

    }


    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Usuario { get; set; }

    public string Contrasena { get; set; }

    public bool Estado { get; set; }

    public System.DateTime FechaCreacion { get; set; }

    public Nullable<System.DateTime> FechaModificacion { get; set; }



    public virtual ICollection<UsuariosServicios> UsuariosServicios { get; set; }

}

}
