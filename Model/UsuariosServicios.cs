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
    using System.ComponentModel.DataAnnotations;
     using Resources;
    public partial class UsuariosServicios
    {
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosIdServicio")]
    public int IdServicio { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosIdUsario")]
    public int IdUsario { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosId")]
    public int Id { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosEstado")]
    public bool Estado { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosFechaCreacion")]
    public System.DateTime FechaCreacion { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosFechaModificacion")]
    public Nullable<System.DateTime> FechaModificacion { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosFechaInicioServicio")]
    public System.DateTime FechaInicioServicio { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosFechaFinServicio")]
    public System.DateTime FechaFinServicio { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelUsuariosServiciosNumeroCreditos")]
    public short NumeroCreditos { get; set; }
    
        public virtual Servicios Servicios { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
