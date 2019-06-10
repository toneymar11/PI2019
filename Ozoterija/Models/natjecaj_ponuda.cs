namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class natjecaj_ponuda
    {
        [Key]
        public int id_natjecaj_ponuda { get; set; }

        public int fk_ponuda { get; set; }

        public int fk_natjecaj { get; set; }

        public virtual natjecaj natjecaj { get; set; }

        public virtual ponuda ponuda { get; set; }
    }
}
