namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("natjecaj")]
    public partial class natjecaj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public natjecaj()
        {
            natjecaj_ponuda = new HashSet<natjecaj_ponuda>();
        }

        [Key]
        public int id_natjecaj { get; set; }

        [Required]
        [StringLength(50)]
        public string tip_natjecaja { get; set; }

        [Required]
        [StringLength(50)]
        public string ime_natjecaja { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime datum_otvaranja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<natjecaj_ponuda> natjecaj_ponuda { get; set; }
    }
}
