using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class Negocio_Contactos
    {
        Datos_Contacto objDato = new Datos_Contacto();

        public List<Entidad_Contactos>ListContacto(string buscar)
        {
            return objDato.ListContactos(buscar);
        }

        public void insercionContacto(Entidad_Contactos contactos)
        {
            objDato.insertarCont(contactos);
        }
        public void edicionContact(Entidad_Contactos contactos)
        {
            objDato.EditarCont(contactos);
        }
        public void eliminarConta(Entidad_Contactos contactos)
        {
            objDato.EliminarCont(contactos);
        }

    }
}
