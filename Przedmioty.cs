namespace SchoolsMarks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// Subject class
    /// </summary>

    [Table("Przedmioty")]
    public partial class Przedmioty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Przedmioty()
        {
            OcenyKońcowe = new HashSet<OcenyKońcowe>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nazwa { get; set; }

        [StringLength(30)]
        public string Nauczyciel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OcenyKońcowe> OcenyKońcowe { get; set; }
    }
}
