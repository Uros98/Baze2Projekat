//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baze2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tiket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tiket()
        {
            this.Dogadjajs = new HashSet<Dogadjaj>();
        }
    
        public int Id { get; set; }
        public double tKv { get; set; }
        public double tDob { get; set; }
        public int KorisnikId { get; set; }
        public int OperaterId { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Operater Operater { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
    }
}