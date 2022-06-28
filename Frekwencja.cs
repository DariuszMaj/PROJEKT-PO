namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Frekwencja")]
    public partial class Frekwencja
    {
        public int ID { get; set; }

        public int? ID_Ucznia { get; set; }

        [Column("Frekwencja")]
        public decimal? Frekwencja1 { get; set; }

        public virtual Uczniowie Uczniowie { get; set; }
    }
}
