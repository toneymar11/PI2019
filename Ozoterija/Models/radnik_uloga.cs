namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class radnik_uloga
    {
        [Key]
        public int id_radnik_uloga { get; set; }

        public int fk_radnik { get; set; }

        public int fk_uloga { get; set; }

        public virtual radnik radnik { get; set; }

        public virtual uloga uloga { get; set; }
    }
}
