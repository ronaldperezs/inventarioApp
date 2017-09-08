using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface ICrudDao<TEntity, TKey> 
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        ICollection<TEntity> listar();
        TEntity consultar(TKey llave);
        void crear(TEntity objeto);
        void actualizar(TEntity objeto);
        void eliminar(TKey llave);
    }
}
