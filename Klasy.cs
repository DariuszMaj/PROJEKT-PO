namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klasy")]
    public partial class Klasy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klasy()
        {
            Uczniowies = new HashSet<Uczniowie>();
        }

        public int ID { get; set; }

        [StringLength(10)]
        public string Nazwa { get; set; }

        [StringLength(30)]
        public string Opiekun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uczniowie> Uczniowies { get; set; }
    }
}
