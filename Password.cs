namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// Password class
    /// </summary>
    public partial class Password
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Login { get; set; }

        [Column("Password")]
        [StringLength(100)]
        public string Password1 { get; set; }

        [StringLength(30)]
        public string Imie { get; set; }

        [StringLength(30)]
        public string Nazwisko { get; set; }
    }
}
