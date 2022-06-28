namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Samorząd
    {
        public int ID { get; set; }

        public int? ID_Ucznia { get; set; }

        [Required]
        [StringLength(30)]
        public string Stanowisko { get; set; }

        public virtual Uczniowie Uczniowie { get; set; }
    }
}
