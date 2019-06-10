namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("najam")]
    public partial class najam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public najam()
        {
            oprema_najam = new HashSet<oprema_najam>();
            radnik_najam = new HashSet<radnik_najam>();
        }

        [Key]
        public int id_najam { get; set; }

        [Required]
        [StringLength(50)]
        public string naziv_najma { get; set; }

        [Required]
        [StringLength(50)]
        public string tip_najma { get; set; }

        public int cijena_najma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema_najam> oprema_najam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_najam> radnik_najam { get; set; }
    }
}
