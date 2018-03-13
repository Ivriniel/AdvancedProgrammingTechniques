using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MojaBiblioteczka.Model
{
    [Serializable]
    [Table("Ksiazka")]
    public class Ksiazka : IEntity<int>
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Tytul { get; set; }

        [Required]
        public string ImieAutora { get; set; }

        [Required]
        public string NazwiskoAutora { get; set; }

        [Required]
        public double Ocena { get; set; }

        public override string ToString()
        {
            return Id + " " + Tytul;
        }

        [XmlIgnore]
        public virtual List<Rozdzial> Rozdzialy { get; set; }
    }
}
