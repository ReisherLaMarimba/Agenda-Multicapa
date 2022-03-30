using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad_Contactos
    {
        private int _idContacto;
        private string _CodigoContacto;
        private string _Nombre;
        private string _Apellido;
        private DateTime _Fecha_Nacimiento;
        private int _Celular;

        public int IdContacto { get => _idContacto; set => _idContacto = value; }
        public string CodigoContacto { get => _CodigoContacto; set => _CodigoContacto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public int Celular { get => _Celular; set => _Celular = value;}
    }
}
