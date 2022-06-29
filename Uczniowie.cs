namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uczniowie")]
    /// <summary>
    /// StudentClass
    /// </summary>
    public partial class Uczniowie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uczniowie()
        {
            Frekwencjas = new HashSet<Frekwencja>();
            OcenyKońcowe = new HashSet<OcenyKońcowe>();
            Samorząd = new HashSet<Samorząd>();
            Wynikis = new HashSet<Wyniki>();
        }

        public int ID { get; set; }

        public int? ID_Klasy { get; set; }

        [Required]
        [StringLength(30)]
        public string Imię { get; set; }

        [Required]
        [StringLength(30)]
        public string Nazwisko { get; set; }

        public int? Numer_Albumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Frekwencja> Frekwencjas { get; set; }

        public virtual Klasy Klasy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OcenyKońcowe> OcenyKońcowe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Samorząd> Samorząd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wyniki> Wynikis { get; set; }
    }
}
