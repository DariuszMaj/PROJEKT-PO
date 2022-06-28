namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wyniki")]
    public partial class Wyniki
    {
        public int ID { get; set; }

        public int? ID_Ucznia { get; set; }

        public int? ID_Egzaminu { get; set; }

        public decimal Wynik { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataPrzystąpienia { get; set; }

        public virtual Egzaminy Egzaminy { get; set; }

        public virtual Uczniowie Uczniowie { get; set; }
    }
}
