namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("oprema")]
    public partial class oprema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public oprema()
        {
            oprema_dogadjaj = new HashSet<oprema_dogadjaj>();
            oprema_najam = new HashSet<oprema_najam>();
            servis = new HashSet<servis>();
        }

        [Key]
        public int id_opreme { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_opreme { get; set; }

        public int kupovna_vrijednost { get; set; }

        public int knjigovodstvena_vrijednost { get; set; }

        [Required]
        [StringLength(50)]
        public string trenutno_stanje { get; set; }

        public int fk_referetni_tip { get; set; }

        public int fk_skladiste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema_dogadjaj> oprema_dogadjaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema_najam> oprema_najam { get; set; }

        public virtual referetni_tip referetni_tip { get; set; }

        public virtual skladiste skladiste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servis> servis { get; set; }
    }
}
