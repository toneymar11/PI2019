namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class radnik_dogadjaj
    {
        [Key]
        public int id_radnik_dogadjaj { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime pocetak_dogadjaja { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime kraj_dogadjaja { get; set; }

        public int plata { get; set; }

        [Required]
        [StringLength(50)]
        public string uloga { get; set; }

        public int fk_radnik { get; set; }

        public int fk_dogadjaj { get; set; }

        public virtual dogadjaj dogadjaj { get; set; }

        public virtual radnik radnik { get; set; }
    }
}
