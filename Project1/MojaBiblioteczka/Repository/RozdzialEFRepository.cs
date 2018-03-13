using MojaBiblioteczka.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public class RozdzialEFRepository: EFRepositoryBase<BibliotekaContext, Rozdzial, int>, IRozdzialRepository
    {
        //BibliotekaContext db = new BibliotekaContext();
        public void InsertRozdzial(Rozdzial rozdzial)
        {
            //try
            //{
            //    db.Set<Rozdzial>().Add(rozdzial);
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //}
            //int id = rozdzial.Id;
            //return id;
        }

        //void IRozdzialRepository.InsertRozdzial(Rozdzial nowyRozdzial)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
