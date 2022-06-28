namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Egzaminy")]
    public partial class Egzaminy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Egzaminy()
        {
            Wynikis = new HashSet<Wyniki>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nazwa { get; set; }

        [StringLength(30)]
        public string OpiekunEgzaminu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wyniki> Wynikis { get; set; }
    }
}
