using GetechMexProjecModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechMexProjec.Interfaces
{
    public interface IFacturaRepository
    {
        Factura ObtenerPorId(int id);
        IEnumerable<Factura> ObtenerTodos();
        void Agregar(Factura factura);
        void Actualizar(Factura factura);
        void Eliminar(int id);
    }
}
