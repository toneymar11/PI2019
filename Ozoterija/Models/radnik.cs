namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("radnik")]
    public partial class radnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public radnik()
        {
            radnik_dogadjaj = new HashSet<radnik_dogadjaj>();
            radnik_najam = new HashSet<radnik_najam>();
            radnik_uloga = new HashSet<radnik_uloga>();
        }

        [Key]
        public int id_radnika { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_radnika { get; set; }

        [Required]
        [StringLength(50)]
        public string prezime_radnika { get; set; }

        public int plata_radnika { get; set; }

        public int fk_grad { get; set; }

        [Required]
        [StringLength(50)]
        public string certifikat_radnika { get; set; }

        public virtual grad grad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_dogadjaj> radnik_dogadjaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_najam> radnik_najam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_uloga> radnik_uloga { get; set; }
    }
}
