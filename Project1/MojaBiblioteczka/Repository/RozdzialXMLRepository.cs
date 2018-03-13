using MojaBiblioteczka.Model;
using MojaBiblioteczka.Repository.Repository.XMLSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public class RozdzialXMLRepository : XMLRepositoryBase<XMLSet<Rozdzial>, Rozdzial, int>, IRozdzialRepository
    {
        private Repository.XMLSource.XMLSet<Rozdzial> m_context;
        public RozdzialXMLRepository()
            : base("rozdzial.xml")
        {
            m_context = new Repository.XMLSource.XMLSet<Rozdzial>("rozdzial.xml");
        }

        public Rozdzial Get(int id)
        {
            return this.GetAll().FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Rozdzial model)
        {
            var list = m_context.Data;
            list.Add(model);
            m_context.Data = list;
            return default(int);
        }

        public ICollection<Rozdzial> GetAll()
        {
            return new Repository.XMLSource.XMLSet<Rozdzial>("rozdzial.xml").Data;
        }

        public bool Update(Rozdzial model)
        {
            try
            {
                IEntity<Rozdzial> imodel = model as IEntity<Rozdzial>;
                List<Rozdzial> items = m_context.Data as List<Rozdzial>;
                items.Remove(items.FirstOrDefault(f => f.Id.Equals(imodel.Id)));
                items.Add((Rozdzial)imodel);
                m_context.Data = items as ICollection<Rozdzial>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                //m_context.Data.Remove(m_context.Data.FirstOrDefault(k => (k.Id == id)));
                List<Rozdzial> items = m_context.Data as List<Rozdzial>;
                items.Remove(items.First(f => f.Id.Equals(id)));
                m_context.Data = items as ICollection<Rozdzial>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InsertRozdzial(Rozdzial nowyRozdzial)
        {
            throw new NotImplementedException();
        }
    }
}
