namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ponuda")]
    public partial class ponuda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ponuda()
        {
            dogadjaj_ponuda = new HashSet<dogadjaj_ponuda>();
            natjecaj_ponuda = new HashSet<natjecaj_ponuda>();
            ponuda_referentni_tip = new HashSet<ponuda_referentni_tip>();
            ponuda_uloga = new HashSet<ponuda_uloga>();
        }

        [Key]
        public int id_ponuda { get; set; }

        [Required]
        [StringLength(50)]
        public string cijena_ponude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dogadjaj_ponuda> dogadjaj_ponuda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<natjecaj_ponuda> natjecaj_ponuda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ponuda_referentni_tip> ponuda_referentni_tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ponuda_uloga> ponuda_uloga { get; set; }
    }
}
