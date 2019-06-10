namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skladiste")]
    public partial class skladiste
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public skladiste()
        {
            oprema = new HashSet<oprema>();
        }

        [Key]
        public int id_skladista { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_sklaldista { get; set; }

        public int fk_grad { get; set; }

        public virtual grad grad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema> oprema { get; set; }
    }
}
