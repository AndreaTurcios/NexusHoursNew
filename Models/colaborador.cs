//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaMVC_Demo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class colaborador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public colaborador()
        {
            this.control_colaborador = new HashSet<control_colaborador>();
        }
    
        public int ID_colaborador { get; set; }
        public string colaborador_nombres { get; set; }
        public string colaborador_apellidos { get; set; }
        public string colaborador_usuario { get; set; }
        public string colaborador_contrasenia { get; set; }
        public string colaborador_telefono { get; set; }
        public string colaborador_correo { get; set; }
        public int colaborador_actividades { get; set; }
    
        public virtual actividades actividades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<control_colaborador> control_colaborador { get; set; }
    }
}