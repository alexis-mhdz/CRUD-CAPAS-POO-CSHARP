using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using CapaEntidades;

namespace CapaDatos
{
    public class D_Empleado
    {
        public List<E_Empleado> ListarEmpleados(string buscar)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                SqlDataReader leerFilas;
                SqlCommand cmd = new SqlCommand("SP_EMPLEADOS_BUSCAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@BUSCAR", buscar);

                leerFilas = cmd.ExecuteReader();

                List<E_Empleado> lista = new List<E_Empleado>();

                while (leerFilas.Read())
                {
                    lista.Add(new E_Empleado
                    {
                        Id = leerFilas.GetInt32(0),
                        Folio = leerFilas.GetString(1),
                        Nombre = leerFilas.GetString(2),
                        Apellidos = leerFilas.GetString(3),
                        Sexo = leerFilas.GetString(4),
                        FechaNacimiento = leerFilas.GetDateTime(5),
                        Puesto = leerFilas.GetString(6),
                        Sueldo = leerFilas.GetDecimal(7)
                    });
                }

                leerFilas.Close();

                return lista;
            }
        }

        public void InsertarEmpleado(E_Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EMPLEADOS_INSERTAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@NOMBRE", empleado.Nombre);
                cmd.Parameters.AddWithValue("@APELLIDOS", empleado.Apellidos);
                cmd.Parameters.AddWithValue("@SEXO", empleado.Sexo);
                cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@PUESTO", empleado.Puesto);
                cmd.Parameters.AddWithValue("@SUELDO", empleado.Sueldo);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditarEmpleado(E_Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EMPLEADOS_EDITAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@ID", empleado.Id);
                cmd.Parameters.AddWithValue("@NOMBRE", empleado.Nombre);
                cmd.Parameters.AddWithValue("@APELLIDOS", empleado.Apellidos);
                cmd.Parameters.AddWithValue("@SEXO", empleado.Sexo);
                cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@PUESTO", empleado.Puesto);
                cmd.Parameters.AddWithValue("@SUELDO", empleado.Sueldo);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarEmpleado(E_Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EMPLEADOS_ELIMINAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@ID", empleado.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
