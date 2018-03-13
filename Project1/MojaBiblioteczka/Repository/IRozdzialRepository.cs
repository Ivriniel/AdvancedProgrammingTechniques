using MojaBiblioteczka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public interface IRozdzialRepository : IRepository<Rozdzial, int>
    {
        void InsertRozdzial(Rozdzial nowyRozdzial);
    }
}
