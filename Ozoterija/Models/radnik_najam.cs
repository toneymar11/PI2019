namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class radnik_najam
    {
        [Key]
        public int id_radnik_najam { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime otkada { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime dokada { get; set; }

        public int plata { get; set; }

        [Required]
        [StringLength(50)]
        public string uloga { get; set; }

        public int fk_radnik { get; set; }

        public int fk_najam { get; set; }

        public virtual najam najam { get; set; }

        public virtual radnik radnik { get; set; }
    }
}
