namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// Mark class
    /// </summary>
    public partial class OcenyKońcowe
    {
        public int ID { get; set; }

        public int? ID_Ucznia { get; set; }

        public int? ID_Przedmiotu { get; set; }

        public int Ocena { get; set; }

        public virtual Przedmioty Przedmioty { get; set; }

        public virtual Uczniowie Uczniowie { get; set; }
    }
}
