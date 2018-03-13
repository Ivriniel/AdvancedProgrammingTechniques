using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojaBiblioteczka.Repository
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>(ContextTypes ctype) where TRepository : class
        {
            switch (ctype)
            {
                case ContextTypes.EntityFramework:
                    if (typeof(TRepository) == typeof(IKsiazkaRepository))
                    {
                        return new KsiazkaEFRepository() as TRepository;
                    }
                    else if (typeof(TRepository) == typeof(IRozdzialRepository))
                    {
                        return new RozdzialEFRepository() as TRepository;
                    }
                    return null;
                case ContextTypes.XMLSource:
                    if (typeof(TRepository) == typeof(IKsiazkaRepository))
                    {
                        return new KsiazkaXMLRepository() as TRepository;
                    }
                    else if (typeof(TRepository) == typeof(IRozdzialRepository))
                    {
                        return new RozdzialXMLRepository() as TRepository;
                    }
                    return null;
                default:
                    return null;
            }
        }
    }
}
