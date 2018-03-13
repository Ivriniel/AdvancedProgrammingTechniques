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
    [Table("Rozdzial")]
    public class Rozdzial : IEntity<int>
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [XmlIgnore, ForeignKey("IdKsiazka")]
        public virtual Ksiazka Ksiazka { get; set; }
        [Required]
        public int IdKsiazka { get; set; }

        [Required, MaxLength(1000)]
        public string Streszczenie { get; set; }
    }
}
