namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dogadjaj")]
    public partial class dogadjaj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dogadjaj()
        {
            dogadjaj_ponuda = new HashSet<dogadjaj_ponuda>();
            oprema_dogadjaj = new HashSet<oprema_dogadjaj>();
            radnik_dogadjaj = new HashSet<radnik_dogadjaj>();
        }

        [Key]
        public int id_dogadjaja { get; set; }

        [Required]
        [StringLength(50)]
        public string naziv_dogadjaja { get; set; }

        public int cijena_dogadjaja { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime datum_dogadjaja { get; set; }

        public int fk_grad { get; set; }

        public virtual grad grad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dogadjaj_ponuda> dogadjaj_ponuda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oprema_dogadjaj> oprema_dogadjaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik_dogadjaj> radnik_dogadjaj { get; set; }
    }
}
