using MojaBiblioteczka.Model;
using MojaBiblioteczka.Repository.Repository.XMLSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public class KsiazkaXMLRepository : XMLRepositoryBase<XMLSet<Ksiazka>, Ksiazka, int>, IKsiazkaRepository
    {
        private Repository.XMLSource.XMLSet<Ksiazka> m_context;

        public KsiazkaXMLRepository()
            : base("ksiazka.xml")
        {
            m_context = new Repository.XMLSource.XMLSet<Ksiazka>("ksiazka.xml");
        }

        public Ksiazka Get(int id)
        {
            return this.GetAll().FirstOrDefault(k => (k.Id == id));
        }

        public int Insert(Ksiazka model)
        {
            var list = m_context.Data;
            list.Add(model);
            m_context.Data = list;
            return default(int);
        }

        public ICollection<Ksiazka> GetAll()
        {
            return new Repository.XMLSource.XMLSet<Ksiazka>("ksiazka.xml").Data;
        }

        public bool Update(Ksiazka model)
        {
            try
            {
                IEntity<Ksiazka> imodel = model as IEntity<Ksiazka>;
                List<Ksiazka> items = m_context.Data as List<Ksiazka>;
                items.Remove(items.FirstOrDefault(f => f.Id.Equals(imodel.Id)));
                items.Add((Ksiazka)imodel);
                m_context.Data = items as ICollection<Ksiazka>;
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
                List<Ksiazka> items = m_context.Data as List<Ksiazka>;
                items.Remove(items.First(f => f.Id.Equals(id)));
                m_context.Data = items as ICollection<Ksiazka>;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
