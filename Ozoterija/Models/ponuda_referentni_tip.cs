namespace Ozoterija.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ponuda_referentni_tip
    {
        [Key]
        public int id_ponuda_referetni_tip { get; set; }

        public int fk_referentni_tip { get; set; }

        public int fk_ponuda { get; set; }

        public virtual ponuda ponuda { get; set; }

        public virtual referetni_tip referetni_tip { get; set; }
    }
}
