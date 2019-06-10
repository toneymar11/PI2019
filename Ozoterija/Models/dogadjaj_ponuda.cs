namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dogadjaj_ponuda
    {
        [Key]
        public int id_dogadjaj_ponuda { get; set; }

        public int fk_dogadjaj { get; set; }

        public int fk_ponuda { get; set; }

        public virtual dogadjaj dogadjaj { get; set; }

        public virtual ponuda ponuda { get; set; }
    }
}
