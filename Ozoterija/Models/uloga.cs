namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("uloga")]
    public partial class uloga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uloga()
        {
            ponuda_uloga = new HashSet<ponuda_uloga>();
            radnik_uloga = new HashSet<radnik_uloga>();
        }

        [Key]
        public int id_uloge { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_uloge { get; set; }

        public int cijena_satnice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ponuda_uloga> ponuda_uloga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_uloga> radnik_uloga { get; set; }
    }
}
