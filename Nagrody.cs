namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nagrody")]
    /// <summary>
    /// Unuseful class YET
    /// </summary>
    public partial class Nagrody
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nazwa { get; set; }
    }
}
