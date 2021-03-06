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
    public partial class Servicios
    {
        public Servicios()
        {
            this.UsuariosServicios = new HashSet<UsuariosServicios>();
        }
    
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosDescripcion")]
    public string Descripcion { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosId")]
    public int Id { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosCosto")]
    public decimal Costo { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosEstado")]
    public bool Estado { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosFechaCreacion")]
    public System.DateTime FechaCreacion { get; set; }
        [Display(ResourceType = typeof(AdminRokuResourcesGlobal), Name = "LabelServiciosFechaModificacion")]
    public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual ICollection<UsuariosServicios> UsuariosServicios { get; set; }
    }
}
