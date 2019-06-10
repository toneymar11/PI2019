namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class servis
    {
        [Key]
        public int id_servisa { get; set; }

        public int cijena_servisa { get; set; }

        [Required]
        [StringLength(50)]
        public string dijelovi { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime datum_servisa { get; set; }

        public int fk_oprema { get; set; }

        public virtual oprema oprema { get; set; }
    }
}
