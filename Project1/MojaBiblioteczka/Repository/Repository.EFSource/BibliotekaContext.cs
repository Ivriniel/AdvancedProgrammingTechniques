using MojaBiblioteczka.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext()
        : base("BibliotekaContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
        }


        public virtual IDbSet<Ksiazka> Ksiazki { get; set; }
        public virtual IDbSet<Rozdzial> Rozdzialy { get; set; }
    }
}
