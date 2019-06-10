namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ponuda_uloga
    {
        [Key]
        public int id_ponuda_uloga { get; set; }

        public int fk_uloga { get; set; }

        public int fk_ponuda { get; set; }

        public virtual ponuda ponuda { get; set; }

        public virtual uloga uloga { get; set; }
    }
}
