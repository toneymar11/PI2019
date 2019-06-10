namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class referetni_tip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public referetni_tip()
        {
            oprema = new HashSet<oprema>();
            ponuda_referentni_tip = new HashSet<ponuda_referentni_tip>();
        }

        [Key]
        public int id_referetni_tip { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_referetni_tip { get; set; }

        public int cijena_referetni_tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema> oprema { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ponuda_referentni_tip> ponuda_referentni_tip { get; set; }
    }
}
