using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class Datos_Contacto
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conectar"].ConnectionString);

        public List<Entidad_Contactos>ListContactos(string buscar)
        {
            SqlDataReader LectorFilas;
            SqlCommand cmd = new SqlCommand("Stored_BuscarContacto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);
            LectorFilas = cmd.ExecuteReader();

            List<Entidad_Contactos> listar = new List<Entidad_Contactos>();
            while (LectorFilas.Read())
            {
                listar.Add(new Entidad_Contactos
                {
                    IdContacto = LectorFilas.GetInt32(0),
                    CodigoContacto = LectorFilas.GetString(1),
                    Nombre = LectorFilas.GetString(2),
                    Apellido = LectorFilas.GetString(3),
                    Fecha_Nacimiento = LectorFilas.GetDateTime(4),
                    Celular = LectorFilas.GetInt32(5),
                }) ;
            }
            conexion.Close();
            LectorFilas.Close();
            return listar;
        }

        public void insertarCont(Entidad_Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("Stored_InsertarContacto", conexion);
            cmd.CommandType = CommandType.StoredProcedure ;
            conexion.Open() ;
            cmd.Parameters.AddWithValue("@Nombre", contactos.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", contactos.Apellido);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", contactos.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@Celular", contactos.Celular);

            cmd.ExecuteNonQuery();
            conexion.Close() ;

        }

        public void EditarCont(Entidad_Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("Stored_EditarContacto",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();    
            cmd.Parameters.AddWithValue("@idcontacto", contactos.IdContacto);
            cmd.Parameters.AddWithValue("@Nombre", contactos.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", contactos.Apellido);
            cmd.Parameters.AddWithValue("@Fecha_Nacimiento", contactos.Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@Celular", contactos.Celular);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCont(Entidad_Contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("Stored_BorrarContacto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idcontacto", contactos.IdContacto);


            cmd.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
