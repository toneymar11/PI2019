namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class oprema_dogadjaj
    {
        [Key]
        public int id_oprema_dogadjaj { get; set; }

        public int fk_oprema { get; set; }

        public int fk_dogadjaj { get; set; }

        public virtual dogadjaj dogadjaj { get; set; }

        public virtual oprema oprema { get; set; }
    }
}
